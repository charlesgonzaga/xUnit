using ProjetoTeste.Application.Clientes;
using ProjetoTeste.Application.Commons;

namespace xUnit.ProjetoTeste.Unit
{
    public class ClienteControllerTest
    {
        [Trait("Unit Test", "ClienteEntity")]
        [Fact(DisplayName = "ClienteEntity_EhMaiorDeIdade_Sim")]
        public void ClienteEntity_EhMaiorDeIdade_Sim()
        {
            // Arrange
            var cliente = new ClienteEntity("João", "Do Pé De Feijão", new DateOnly(2005, 2, 12), StatusAtivo.Sim)
            {
                Id = 1
            };

            // Act
            var result = cliente.EhMaiorDeIdade();

            // Assert
            Assert.True(result);
        }

        [Trait("Unit Test", "ClienteEntity")]
        [Fact(DisplayName = "ClienteEntity_EhMaiorDeIdade_Nao")]
        public void ClienteEntity_EhMaiorDeIdade_Nao()
        {
            var dataMenorIdade = DateOnly.FromDateTime(DateTime.Now.AddYears(-17));

            // Arrange
            var cliente = new ClienteEntity("João", "Do Pé De Feijão", dataMenorIdade, StatusAtivo.Sim)
            {
                Id= 1
            };

            // Act
            var result = cliente.EhMaiorDeIdade();

            // Assert
            Assert.False(result);
        }
    }
}