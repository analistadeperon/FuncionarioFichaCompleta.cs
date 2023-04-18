public class Funcionario
{
   public int Cod get; set; }
   public string Nome get; set; }
   public string Sobrenome get; set; }
   public string Setor get; set; }
   public string Cidade get; set; }
}
using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;

namespaceWindowsFormsCadastro;
{
   public partial class FrmCadastro : Form
       public static string webserviceFuncionario =
       "http://localhost:49686/Api/funcionario";
       
private void btnAtualizar_Click(object sender, EventArgs e)
     {
       AtualizarFuncionario(1);
     }

     private async void AtualizarFuncionario (int cod_funcionario)
     {
       string URI = webserviceFuncionario;
         Funcionario funcionario = new Funcionario();
         funcionario.Nome = "Thiago Cavalheiro";
         funcionario.Sobrenome = "Montebugnoli";
         funcionario.Setor = "Informática";
         funcionario.Cidade = "Avaré";

         using (var cliente =new HttpClient())
         {
           var serializedFuncionario =
           JsonConvert.SerializeObject(funcionario);
           var content = new
           StringContent(serializedFuncionario,
           Encoding.UTF8, "application/json");
           HttpResponseMessage responseMessage = await
           cliente.PutAsync(URI + "?cod=" + cod_funcionario,content);

           if (responseMessage.IsSuccessStatusCode)
           {
             MessageBox.Show("Funcionário atualizado");
           }
           else
           {
             MessageBox.Show("Falha ao atualizar o
             funcionário : " + responseMessage.StatusCode);
           }
         }
         RetornarDados();
     }

     // Excluir comando abaixo:

     private void btnExcluir_Click(object sender, EventArgs e)
     {
       ExcluirFuncionario(1);
     }

     private async void ExcluirFuncionario(int cod_funcionario)
     {
       string URI = webserviceFuncionario;
       using (var cliente = new HttpClient())
       {
         cliente.BaseAddress = new Uri(URI);
         HttpResponseMessage responseMessage = await
         cliente.DeleteAsync(URI + "?cod=" + cod_funcionario);

         if (responseMessage.IsSuccessStatusCode)
         {
           MessageBox.Show("Funcionário excluído
           com sucesso!");
         }
         else
         {
           MessageBox.Show("Falha ao excluir o
           funcionário : " + responseMessage.StatusCode);
         }
       }
       RetornarDados();
     }

