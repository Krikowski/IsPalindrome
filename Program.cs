using System.Globalization;
using System.Text;

namespace IsPalindrome {

    internal class Program {
        public class PalindromeChecker {
            private readonly IStringCleaner _stringCleaner;

            /// <summary>
            /// Injeção de dependência através do construtor
            /// </summary>
            public PalindromeChecker(IStringCleaner stringCleaner) {
                _stringCleaner = stringCleaner;
            }

            /// <summary>
            /// Método para verificar se a string é um palíndromo
            /// </summary>
            public bool IsPalindrome(string input) {
                if (string.IsNullOrWhiteSpace(input)) return false;


                string processedInput = _stringCleaner.CleanString(input);
                string reversed = ReverseString(processedInput);
                return processedInput == reversed;
            }

            /// <summary>
            /// Método para inverter a string
            /// </summary>
            private string ReverseString(string input) {
                Span<char> buffer = stackalloc char[input.Length];
                input.AsSpan().CopyTo(buffer);
                buffer.Reverse();
                return new string(buffer);
            }

        }

        /// <summary>
        /// Interface para limpeza de strings.
        /// </summary>
        public class DefaultStringCleaner : IStringCleaner {

            /// <summary>
            /// normaliza a string para decompor caracteres acentuados, remove pontuação e espaços.
            /// </summary>
            /// <param name="input">a string original.</param>
            /// <returns>a string limpa e normalizada.</returns>
            /// Esta implementação é fixa por simplicidade (YAGNI). Se o requisito evoluir, podemos aplicar estratégia com filtros configuráveis.

            public string CleanString(string input) {

                string normalized = input.Normalize(NormalizationForm.FormD);
                var filteredChars = normalized.Where(c =>
                    CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark &&
                    !char.IsPunctuation(c) &&
                    !char.IsWhiteSpace(c));

                string clean = new string(filteredChars.ToArray());
                return clean.Normalize(NormalizationForm.FormC).ToLower();
            }
        }

        public interface IStringCleaner {
            string CleanString(string input);
        }

        static void Main(string[] args) {

            var stringCleaner = new DefaultStringCleaner();
            var palindromeChecker = new PalindromeChecker(stringCleaner);

            string[] testInputs = { "A man, a plan, a canal: Panama", "race a car", "", " " };

            foreach (var input in testInputs) {
                ProcessPalindromeCheck(input, palindromeChecker);
            }
        }

        private static void ProcessPalindromeCheck(string input, PalindromeChecker checker) {
            bool isPalindrome = checker.IsPalindrome(input);
            Console.WriteLine($"'{input}' -> {(isPalindrome ? "É um palíndromo!" : "Não é um palíndromo.")}");
        }
    }
}
