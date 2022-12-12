namespace Application.Shared.StringManipulation.Implementations
{
    internal class StringManipulationService : IStringManipulationService
    {
        public StringManipulationService()
        {

        }
        public String standarizeText(String Text)
        {
            return Text.Replace('á', 'a')
                       .Replace('é', 'e')
                       .Replace('í', 'i')
                       .Replace('ó', 'o')
                       .Replace('ú', 'u')
                       .Replace('ü', 'u')
                       .Replace('ñ', 'n');
        }
    }
}
