using Xunit;
using API_Cadastro.Controllers;
using Moq;

namespace API_Cadastro.Controller.Testes
{
    public class UserControllerTestes
    {

        private UserController userController;

        public UserControllerTestes()
        {
            userController = new UserController(new Mock<IUserController>().Object, new Mock<IMapper>().Object);
        }

        /*
        [Fact]
        public void Test1()
        */
    }
}