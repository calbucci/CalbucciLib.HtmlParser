using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using CalbucciLib.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalbucciLib.HtmlPaser.Tests
{
	[TestClass]
	public class HtmlParserTests
	{



		[TestMethod]
		public void SimpleSegments()
		{
			TestSegments(true, new[]
			{
				null,
				"",
				"text only",
				"text only with &gt; entities",
				"<b></b>",
				"<b>bold</b>",
				"a<b>bold</b>",
				"a<b>bold</b>b",
				"<b>bold<i>italic-bold</i>bold</b>"
			});
		}

		[TestMethod]
		public void OptionalClosing()
		{
			TestSegments(true,
				new[]
				{
					"<p>",
					"a<p>",
					"a<p>b",
					"a<p>b</p>c",
					"a<p>b<br>c</p>",
					"a<p>b<br>c",
					"a<p>b</p><p>c</p>",
					"a<p>b</p><p>c",
					"a<p>b<p>c",
					"a<p>b<b>c</b>d</p><p>e</p>",
					"a<p>b<b>c</b>d</p><p>e",
					"a<p>b<b>c</b>d<p>e"
				});
		}

		[TestMethod]
		public void OptionalClosingWithBlockElement()
		{
			TestSegments(true, new[]
			{
				"<ul><li><div>a</div></li></ul>",
				"<ul><li>a<div>b</div></li></ul>",
				"<ul><li><div>a</div>b</li></ul>",
				"<ul><li><div>a</div></ul>",
				"<ul><li>a<div>b</div></ul>",
				"<ul><li><div>a</div>b</ul>",
			});
		}

		[TestMethod]
		public void Scripts()
		{
			TestSegments(true, new[]
			{
				"<script src=abc></script>",
				"<script>if(a<b) c;</script>",
				"abc<script>if(a<b) c;</script>def",
			});
		}

		[TestMethod]
		public void Comments()
		{
			TestSegments(true, new []
			{
				"<!-- comment -->",
				"<!-- this is <b>a long comment</b> -->",
				"abcd<!-- comments <b>bold</bold> -->ghij"
			});
		}

		[TestMethod]
		public void Table()
		{
			TestSegments(true, new []
			{
				"<table> <tr> <td>a</td> </table>",
				"<table> <tr> <td>a</table>",
				"<table> <tr> <td><p>a</table>"
			});
		}

		[TestMethod]
		public void CompleteHtml()
		{
			TestSegments(true, new []
			{
				"<html><head><title>title</title></head><body>body</body></html>",
				"<html><head><title>hello</title><body>body",
				@"<!doctype html public ""-//w3c//dtd html 4.0 strict//en""><html><head><title>title</title></head><body>body</body></html>",

			});
		}

		[TestMethod]
		public void SingleTags()
		{
			TestSegments(true, new[]
			{
				"<br>",
				"<hr>",
				"<br/>",
				"<br />",
				"< br />",
				"< br / >",
				"<hr size=1>",
				"<hr size=\"1\">",
				"<hr size=1/>",
				"<hr size=\"1\"/>"
			});
		}

		[TestMethod]
		public void Attributes()
		{
			TestSegments(true, new []
			{
				"<a href></a>",
				"<font size=1 face=verdana>a</font>",
				"<font size=\"1\" face=verdana>a</font>",
				"<font size=1 face=\"verdana\">a</font>",
				"<font size=\"1\" face=\"verdana\">a</font>",
			});
			
		}

		[TestMethod]
		public void StyleTag()
		{
			TestSegments(true, new []
			{
				"<head><style>.a { background-url: 'ab<>c.jpg'; }</style></head>"
			});
		}


		[TestMethod]
		public void InvalidSegments()
		{
			TestSegments(false, new []
			{
				"<",
				"<b",
				"<hr",
				"<>",
				"< >",
				" < > ",
				"<b>",
				"a<b>b<i>c</b>d</i>e",
				"<a href=></a>",
				"<a href=\"abc></a>",
				"<!-- missing closing"
			});
		}

		[TestMethod]
		public void InnerText()
		{
			var segments = new Tuple<string,string>[]
			{
				new Tuple<string, string>("", "<b></b>"),
				new Tuple<string, string>("a", "<b>a</b>"),
				new Tuple<string, string>("a", "a<b></b>"),
				new Tuple<string, string>("a", "<b></b>a"),
				new Tuple<string, string>("abc", "a<b>b</b>c"),
				new Tuple<string, string>("ac", "a<!--b-->c"),
			};

			foreach (var segment in segments)
			{
				var parser = new HtmlParser(segment.Item2);
				Assert.IsTrue(parser.Parse());
				Assert.IsTrue(segment.Item1 == parser.InnerText);
			}
		}

		[TestMethod]
		public void PreserveComments()
		{
			string segment = "a<b>b<!--comment-->c</b>d";
			var parser = new HtmlParser(segment);
			parser.SkipComments = false;
			Assert.IsTrue(parser.Parse());
			Assert.AreEqual(parser.InnerText, "ab<!--comment-->cd");
		}

		[TestMethod]
		public void ComplexHtml()
		{
			HtmlParser parser = new HtmlParser(TestContent.GoogleHomepage);
			parser.Parse();
			Assert.IsTrue(parser.HasValidSyntax);
		}

		[TestMethod]
		public void CustomInnerText()
		{
			string segment = "a<b>b</b>c<!--comment-->d<p>e";
			var sb = new StringBuilder();
			var parser = new HtmlParser(segment);
			parser.Parse((text, he) => sb.Append(text));

			Assert.AreEqual(sb.ToString(), "abcde");
		}

		[TestMethod]
		public void UrlAttribute()
		{
			var segment =
				@"<b> <link rel=""alternate"" type=""application/rss+xml"" title=""M-Shaped Brain &raquo; Feed"" href=""http://blog.calbucci.com/feed/"" /> </b>";

			bool foundIt = false;
			var parser = new HtmlParser(segment);
			parser.Parse(null, (element, isEmptyTag) =>
			{
				if (element.TagName == "link")
				{
					Assert.IsTrue(element.Attributes.Count == 4);
					Assert.AreEqual(element.GetAttributeValue("title"), "M-Shaped Brain » Feed");
					Assert.AreEqual(element.GetAttributeValue("href"), "http://blog.calbucci.com/feed/");
					foundIt = true;
				}
			});

			Assert.IsTrue(foundIt);
		}

		[TestMethod]
		public void FindRSSFeed()
		{
			var parser = new HtmlParser(TestContent.BlogPost);
			string rssFeed = null;
			parser.Parse(null, (HtmlElement element, bool isEmptyTag) =>
			{
				if (element.TagName == "link")
				{
					if (element.GetAttributeValue("type") == "application/rss+xml")
					{
						rssFeed = element.GetAttributeValue("href");
						parser.Stop();
					}
				}
			});

			Assert.AreEqual(rssFeed, "http://blog.calbucci.com/feed/");
		}

		[TestMethod]
		public void Idempotent()
		{
			string html1 = ParseAndSerialize(TestContent.BlogPost);
			string html2 = ParseAndSerialize(html1);
			string html3 = ParseAndSerialize(html2);

			int maxLen = Math.Min(html1.Length, html2.Length);
			for (int i = 0; i < maxLen; i++)
			{
				var c1 = html1[i];
				var c2 = html2[i];

				if (c1 != c2)
				{
					int ps1 = Math.Max(i - 30, 0);
					int pe1 = Math.Min(ps1 + 60, html1.Length);

					int ps2 = Math.Max(i - 30, 0);
					int pe2 = Math.Min(ps2 + 60, html2.Length);

					string seg1 = html1.Substring(ps1, pe1 - ps1);
					string seg2 = html2.Substring(ps2, pe2 - ps2);

					Assert.Fail("Mismatch idempotent [{0}] [{1}]", seg1, seg2);
				}

			}

			Assert.AreEqual(html1, html2);
			Assert.AreEqual(html2, html3);
		}

		private string ParseAndSerialize(string html)
		{
			var parser = new HtmlParser(html);
			parser.PreserveCRLFTab = false;
			StringBuilder sb = new StringBuilder(html.Length);
			parser.Parse(
				(text, parent) =>
				{
					sb.Append(WebUtility.HtmlEncode(text));
				},
				(parent, isEmptyTag) =>
				{
					sb.Append(parent.GetOpenTag(false, false));
				},
				(closeTag) =>
				{
					sb.AppendFormat("</{0}>", closeTag);
				});

			return sb.ToString();
		}

		[TestMethod]
		public void FindOpenGraphTags()
		{
			var parser = new HtmlParser(TestContent.BlogPost);
			Dictionary<string, string> tags = new Dictionary<string, string>();
			parser.Parse(null, (HtmlElement element, bool isEmptyTag) =>
			{
				if (element.TagName == "meta")
				{
					string ogName = element.GetAttributeValue("property");
					if (ogName == null || !ogName.StartsWith("og:"))
						return;
					string ogValue = element.GetAttributeValue("content");
					tags[ogName] = ogValue;
				}
			});
			Assert.IsTrue(parser.HasValidSyntax);

			Assert.AreEqual(tags["og:type"], "article");
			Assert.AreEqual(tags["og:url"], "http://blog.calbucci.com/2015/01/27/attention-cannibalization/");

		}


		private void TestSegments(bool result, string[] segments)
		{
			foreach (var segment in segments)
			{
				HtmlParser parser = new HtmlParser(segment);
				Assert.IsTrue(parser.Parse() == result, "Failed to parse segment: " + segment);
			}
		}


	}
}
