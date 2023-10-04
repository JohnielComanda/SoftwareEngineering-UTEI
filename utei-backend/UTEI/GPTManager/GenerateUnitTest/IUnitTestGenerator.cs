namespace UTEI.GPTManager.GenerateUnitTest
{
    public interface IUnitTestGenerator
    {
        Task<string> Generator(string progLang, string baseMethod);
    }
}
