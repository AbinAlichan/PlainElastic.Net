﻿using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(NGramTokenizer))]
    class When_complete_NGramTokenizer_built
    {
        Because of = () => result = new NGramTokenizer()
                                            .Name("name")
                                            .Version("3.6")
                                            .MinGram(10)
                                            .MaxGram(20)
                                            .CustomPart("{ Custom }")
                                            .ToString();

        It should_start_with_name = () => result.ShouldStartWith("'name': {".AltQuote());

        It should_contain_type_part = () => result.ShouldContain("'type': 'nGram'".AltQuote());

        It should_contain_version_part = () => result.ShouldContain("'version': '3.6'".AltQuote());

        It should_contain_min_gram_part = () => result.ShouldContain("'min_gram': 10".AltQuote());

        It should_contain_max_gram_part = () => result.ShouldContain("'max_gram': 20".AltQuote());

        It should_contain_custom_part = () => result.ShouldContain("{ Custom }".AltQuote());
        
        It should_return_correct_result = () => result.ShouldEqual(("'name': { " +
                                                                    "'type': 'nGram'," +
                                                                    "'version': '3.6'," +
                                                                    "'min_gram': 10," +
                                                                    "'max_gram': 20," +
                                                                    "{ Custom } }").AltQuote());

        private static string result;
    }
}