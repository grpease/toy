using System;
using Xunit;
using Tendo.Services;
using Tendo.Services.Interfaces;
using Tendo.Models;
using System.Linq;
using System.Text;

namespace Tendo.Tests
{
    public class SentimentAnalysisTests
    {
        [Fact]
        public void SimpleSentimentAnalysisTest()
        {
            ISentimentAnalysisService service = new SimpleSentimentAnalysis();
            Assert.Equal(0.5F, service.AnalyzeText("maybe"));
            Assert.Equal(1F, service.AnalyzeText("yes"));
            Assert.Equal(1F, service.AnalyzeText("Yes"));
            Assert.Equal(1F, service.AnalyzeText("YES!!!!!!!!!!!!"));
            Assert.Equal(0F, service.AnalyzeText("no"));
            Assert.Equal(0F, service.AnalyzeText("NO!!!!!!"));
        }
        [Fact]
        public void ComplexSentimentAnalysisTest() {
            ISentimentAnalysisService service = new ComplexSentimentAnalysis();
            Assert.Equal(0.5F, service.AnalyzeText("uncertain"));
            Assert.Equal(0.49F, service.AnalyzeText("unhappy"));
            Assert.Equal(0.51F, service.AnalyzeText("relieved"));
            Assert.Equal(0, service.AnalyzeText(StringRepeater("unhappy", 100)));
            Assert.Equal(0.99F, service.AnalyzeText(StringRepeater("relieved", 49)), 3);
        }

        private string StringRepeater(string word, int count)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < count; i++) {
                if (i >0)
                    builder.Append(" ");
                builder.Append(word);
            }
            return builder.ToString();
        }
    }
}
