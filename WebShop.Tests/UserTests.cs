using System;
using WebShop.Logic;
using Xunit;

namespace WebShop.Tests
{
    public class UserTests
    {
        [Fact]
        public void TestCreateUser()
        {
            string mail = GetRandomText();
            UserManager.Create(mail, "testname", "testpass");

            var user = UserManager.GetByEmail(mail);

            // ja asertācija ir pareiza -> tests ir veiksmīgs
            Assert.NotNull(user);
            Assert.Equal(user.Email, mail);
        }

        [Fact]
        public void TestGetUser()
        {
            string mail = GetRandomText();
            string password = "testpass";
            UserManager.Create(mail, "testname", password);

            var user = UserManager.GetByEmailAndPassword(mail, password);
            Assert.NotNull(user);
            Assert.Equal(user.Email, mail);
            Assert.Equal(user.Password, password);
        }

       /* [Fact]
        public void TestGetCategory()
        {
            string id = GetRandomNumber();
            CategoryManager.Create("testname", id);

            var category = CategoryManager.Get(id);
            Assert.NotNull(category);
            Assert.Equal(category.Id, id);
        }

        [Fact]
        public void TestCreateCategory()
        {
            string id = GetRandomNumber();
            string name = GetRandomText();
            CategoryManager.Create(name, id);

            var category = CategoryManager.GetAll(name, id);
            Assert.NotNull(category);
            Assert.Equal(category.ParentId, id);
            Assert.Equal(category.Name, name);
        }

        [Fact]
        public void TestGetItem()
        {
            string catid = GetRandomNumber();
            ItemManager.Create(catid, "testname", "testdes", "testprice");

            var item = ItemManager.GetByCategory(catid);
            Assert.NotNull(item);
            Assert.Equal(item.CategoryId, catid);
        }

        [Fact]
        public void TestCreateItem()
        {
            string catid = GetRandomNumber();
            string name = GetRandomText();
            string des = GetRandomText();
            string price = GetRandomNumber();
            ItemManager.Create(catid, name, des, price);

            var item = ItemManager.GetAll(catid, name, des, price);
            Assert.NotNull(item);
            Assert.Equal(item.CategoryId, catid);
            Assert.Equal(item.Name, name);
            Assert.Equal(item.Description, des);
            Assert.Equal(item.Price, price);
        }*/

        public static string GetRandomText()
        {
            return Guid.NewGuid().ToString("N").Substring(0, 8);
        }

        public static string GetRandomNumber()
        {
            return Guid.NewGuid().ToString("N").Substring(0, 4);
        }
    }
}
