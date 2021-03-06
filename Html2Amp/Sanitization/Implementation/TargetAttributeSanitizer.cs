﻿using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using ComboRox.Core.Utilities.SimpleGuard;

namespace Html2Amp.Sanitization.Implementation
{
	public class TargetAttributeSanitizer : Sanitizer
	{
		public override bool CanSanitize(IElement element)
		{
			if (element == null || !(element is IHtmlAnchorElement))
			{
				return false;
			}

			var targetAttributeValue = element.GetAttribute("target");

			return targetAttributeValue != null && targetAttributeValue != "_blank";
		}

		public override IElement Sanitize(IDocument document, IElement htmlElement)
		{
			Guard.Requires(htmlElement, "htmlElement").IsNotNull();

			htmlElement.SetAttribute("target", "_blank");

			return htmlElement;
		}
	}
}