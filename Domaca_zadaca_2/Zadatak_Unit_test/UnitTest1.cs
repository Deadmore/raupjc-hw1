using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Remoting;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadatak_2;

namespace Zadatak_Unit_test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMarkAsCompletedAndIsCompleted()
        {
            TodoItem pom1 = new TodoItem("String 1");

            if (pom1.IsCompleted)
            {
                Assert.Fail();
            }
            pom1.MarkAsCompleted();
            if (pom1.IsCompleted)
            {
                return;
            }
            Assert.Fail();
        }

        [TestMethod]
        public void TestAdd()
        {
            TodoItem pom1 = new TodoItem("String 1");
            TodoItem pom2 = new TodoItem("String 2");
            TodoItem pom3 = new TodoItem("String 3");

            TodoRepository lista = new TodoRepository();
            try
            {
                lista.Add(pom1);
                lista.Add(pom2);
                lista.Add(pom3);
                lista.Add(pom1);
            }
            catch (Exception e)
            {
                Console.WriteLine("pokusano ponovno dodat istog clana");
                return;
            }
            Assert.Fail();
        }

        [TestMethod]
        public void TestGet()
        {
            TodoItem pom1 = new TodoItem("String 1");
            TodoItem pom2 = new TodoItem("String 2");
            TodoItem pom3 = new TodoItem("String 3");

            TodoRepository lista = new TodoRepository();
            try
            {
                lista.Add(pom1);
                lista.Add(pom2);
                lista.Add(pom3);
            }
            catch (Exception e)
            {
                Console.WriteLine("pokusano ponovno dodat istog clana");
            }

            pom2 = lista.Get(pom1.Id);
            if (pom2 == pom1)
            {
                return;
            }
            Assert.Fail();
        }

        [TestMethod]
        public void TestRemove()
        {
            TodoItem pom1 = new TodoItem("String 1");
            TodoItem pom2 = new TodoItem("String 2");
            TodoItem pom3 = new TodoItem("String 3");

            TodoRepository lista = new TodoRepository();
            try
            {
                lista.Add(pom1);
                lista.Add(pom2);
                lista.Add(pom3);
                lista.Remove(pom1.Id);
                lista.Add(pom1);
            }
            catch (Exception e)
            {
                Assert.Fail();
            }

            return;
        }

        [TestMethod]
        public void TestUpdate()
        {
            TodoItem pom1 = new TodoItem("String 1");
            TodoItem pom2 = new TodoItem("String 2");
            TodoRepository lista = new TodoRepository();

            lista.Add(pom1);
            pom1.MarkAsCompleted();
            

            pom2.Id = pom1.Id;

            lista.Update(pom2);

            if (pom1.Text == pom2.Text)
            {
                return;
            }
            Assert.Fail();
        }

        [TestMethod]
        public void TestMarkasCompleted()
        {
            TodoItem pom1 = new TodoItem("String 1");
            TodoRepository lista = new TodoRepository();

            lista.Add(pom1);
            lista.MarkAsCompleted(pom1.Id);

            if (pom1.IsCompleted)
            {
                return;
            }
            Assert.Fail();
        }

        [TestMethod]
        public void TestGetAll()
        {
            TodoItem pom1 = new TodoItem("String 1");
            TodoItem pom2 = new TodoItem("String 2");
            Thread.Sleep(1);
            TodoItem pom3 = new TodoItem("String 3");
            TodoItem pom4 = new TodoItem("String 4");
            Thread.Sleep(1);
            TodoItem pom5 = new TodoItem("String 5");
            TodoItem pom6 = new TodoItem("String 6");

            TodoRepository lista = new TodoRepository();

            lista.Add(pom6);
            lista.Add(pom4);
            lista.Add(pom1);
            lista.Add(pom3);
            lista.Add(pom2);
            lista.Add(pom5);

            List<TodoItem> lista1 = lista.GetAll();

            foreach (TodoItem item in lista1)
            {
                Console.WriteLine(item.Text);
            }
        }

        [TestMethod]
        public void TestGetActive()
        {
            TodoItem pom1 = new TodoItem("String 1");
            TodoItem pom2 = new TodoItem("String 2");
            Thread.Sleep(1);
            TodoItem pom3 = new TodoItem("String 3");
            TodoItem pom4 = new TodoItem("String 4");
            Thread.Sleep(1);
            TodoItem pom5 = new TodoItem("String 5");
            TodoItem pom6 = new TodoItem("String 6");

            pom1.MarkAsCompleted();
            pom3.MarkAsCompleted();
            pom5.MarkAsCompleted();

            TodoRepository lista = new TodoRepository();

            lista.Add(pom6);
            lista.Add(pom4);
            lista.Add(pom1);
            lista.Add(pom3);
            lista.Add(pom2);
            lista.Add(pom5);

            List<TodoItem> lista1 = lista.GetActive();

            foreach (TodoItem item in lista1)
            {
                Console.WriteLine(item.Text);
            }
        }

        [TestMethod]
        public void TestGetCompleted()
        {
            TodoItem pom1 = new TodoItem("String 1");
            TodoItem pom2 = new TodoItem("String 2");
            Thread.Sleep(1);
            TodoItem pom3 = new TodoItem("String 3");
            TodoItem pom4 = new TodoItem("String 4");
            Thread.Sleep(1);
            TodoItem pom5 = new TodoItem("String 5");
            TodoItem pom6 = new TodoItem("String 6");

            pom1.MarkAsCompleted();
            pom3.MarkAsCompleted();
            pom5.MarkAsCompleted();

            TodoRepository lista = new TodoRepository();

            lista.Add(pom6);
            lista.Add(pom4);
            lista.Add(pom1);
            lista.Add(pom3);
            lista.Add(pom2);
            lista.Add(pom5);

            List<TodoItem> lista1 = lista.GetCompleted();

            foreach (TodoItem item in lista1)
            {
                Console.WriteLine(item.Text);
            }
        }

        [TestMethod]
        public void TestGetFiltered(Func<TodoItem,bool> funkcija)
        {
            TodoItem pom1 = new TodoItem("String 1");
            TodoItem pom2 = new TodoItem("String 2");
            Thread.Sleep(1);
            TodoItem pom3 = new TodoItem("String 3");
            TodoItem pom4 = new TodoItem("String 4");
            Thread.Sleep(1);
            TodoItem pom5 = new TodoItem("String 5");
            TodoItem pom6 = new TodoItem("String 6");

            pom1.MarkAsCompleted();
            pom3.MarkAsCompleted();
            pom5.MarkAsCompleted();

            TodoRepository lista = new TodoRepository();

            lista.Add(pom6);
            lista.Add(pom4);
            lista.Add(pom1);
            lista.Add(pom3);
            lista.Add(pom2);
            lista.Add(pom5);

            List<TodoItem> lista1 = lista.GetFiltered(funkcija);

            foreach (TodoItem item in lista1)
            {
                Console.WriteLine(item.Text);
            }
        }
    }

}


