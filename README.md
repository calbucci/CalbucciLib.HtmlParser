# CalbucciLib.HtmlParser

CalbucciLib.HtmlParser is a SAX-like HTML 5.0 compliant Parser for fast parsing of HTML documents without building the DOM.


## Typical Scenarios
- Use it to scrape pieces of HTML
- Detect META / LINK tags (e.g. Open Graph tags)
- Optimize the output HTML (remove whitespace, clear empty tags)
- Detect HTML syntax errors and notify developers
- Extract text from the HTML


## Sample

### Get the RSS Feed of a website

```csharp
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
```

### Remove whitespaces

```csharp
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
```



## Questions



## Contributors

- HtmlParser was originally created by *Marcelo Calbucci* ([blog.calbucci.com](http://blog.calbucci.com) | [@calbucci](http://twitter.com/calbucci))
