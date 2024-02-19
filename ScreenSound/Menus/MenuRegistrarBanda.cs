using OpenAI_API;
using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuRegistrarBanda : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        base.Executar(bandasRegistradas);
        ExibirTituloDaOpcao("Registro das bandas");
        Console.Write("Digite o nome da banda que deseja registrar: ");
        string nomeDaBanda = Console.ReadLine()!;
        Banda banda = new Banda(nomeDaBanda);
        bandasRegistradas.Add(nomeDaBanda, banda);

        var Client = new OpenAIAPI("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");

        var Chat = Client.Chat.CreateConversation();

        Chat.AppendSystemMessage($"Resuma a banda {nomeDaBanda} em 1 paragrafo, adote uma escrita informal");

        string Resposta =  Chat.GetResponseFromChatbotAsync().GetAwaiter().GetResult();
        banda.Resumo = Resposta;

        Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}
