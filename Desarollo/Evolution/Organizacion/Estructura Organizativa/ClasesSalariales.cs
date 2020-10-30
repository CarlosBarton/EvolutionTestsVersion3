using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using Shared;
using OpenQA.Selenium.Interactions;


namespace EvolutionAutomationTests.Desarollo.Evolution.Organizacion.Estructura_Organizativa
{

    [TestFixture]
    public class ClasesSalariales
    {

        IWebDriver driver;
        WebDriverWait wait;
        Actions actions;
        string txtDescripcionExpected, txtMinimoExpected, txtMedioExpected, txtMaximoExpected, txtCompaniaExpected;

        [OneTimeSetUp]
        public void SetUp()
        {
            //Inicialización de variables
            CommonLogic commonLogic = new CommonLogic();
            driver = WebDriverSingleton.GetInstance();
            actions = new Actions(driver);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            txtDescripcionExpected = "Descripcion";
            txtMinimoExpected = "1500";
            txtMedioExpected = "2000";
            txtMaximoExpected = "2500";
            txtCompaniaExpected = "1";

            //Ir a pantalla de clases salariales
            IWebElement applicacion = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='menucenter']/a[2]")));
            applicacion.Click();
            IWebElement modulo = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='innerright']/table[1]/tbody/tr/td/div[1]/div[2]/h2/a")));
            modulo.Click();
            IWebElement seccion = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='innerright']/div[2]/fieldset[3]/h4/a")));
            seccion.Click();
            IWebElement opcion = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='innerright']/div[2]/fieldset[3]/div/div[2]/div[1]/div[2]/h2/a")));
            opcion.Click();
        }

        [Test, Order(1)]
        public void Crear_Clase_Salarial_Con_Informacion_Basica()
        {
            //Crear nueva clase salarial
            IWebElement btnNuevo = driver.FindElement(By.Id("smlClaseSalarial_new"));
            btnNuevo.Click();
            IWebElement txtDescripcion = driver.FindElement(By.Id("Descripcion"));
            txtDescripcion.SendKeys(txtDescripcionExpected);
            IWebElement cmbCompania = driver.FindElement(By.Id("CodigoCompania"));
            cmbCompania.Click();
            IWebElement Corporativo = driver.FindElement(By.XPath("//*[@id='CodigoCompania']/option[2]"));
            Corporativo.Click();
            IWebElement txtMinimo = driver.FindElement(By.Id("Minimo"));
            txtMinimo.SendKeys(txtMinimoExpected);
            IWebElement txtMedio = driver.FindElement(By.Id("Medio"));
            txtMedio.SendKeys(txtMedioExpected);
            IWebElement txtMaximo = driver.FindElement(By.Id("Maximo"));
            txtMaximo.SendKeys(txtMaximoExpected);            
            IWebElement btnGuardar = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Name("btnGuardarClaseSalarial")));
            btnGuardar.Click();

            //Editar clase salarial creada
            IWebElement txtBuscar = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("smlClaseSalarial_txtQuickSearch")));
            txtBuscar.SendKeys(txtDescripcionExpected);
            txtBuscar.SendKeys(Keys.Enter);
            txtBuscar.SendKeys(Keys.Enter);
            IWebElement tblRegistro = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//*[@id='smlClaseSalarial_grid']/div[3]/table/tbody/tr")));
            actions.DoubleClick(tblRegistro).Perform();

            //Verificaciones
            IWebElement txtDescripcionActual = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("Descripcion")));
            string txtDescripcionActualTexto = txtDescripcionActual.GetAttribute("value");
            Assert.AreEqual(txtDescripcionExpected, txtDescripcionActualTexto);

            IWebElement txtCompaniaActual = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("CodigoCompania")));
            string txtCompaniaTexto = txtCompaniaActual.GetAttribute("value");
            Assert.AreEqual(txtCompaniaExpected, txtCompaniaTexto);

            IWebElement txtMinimoActual = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("Minimo")));
            string txtMinimoActualTexto = txtMinimoActual.GetAttribute("value");
            Assert.AreEqual(txtMinimoExpected, txtMinimoActualTexto);

            IWebElement txtMedioActual = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("Medio")));
            string txtMedioActualTexto = txtMedioActual.GetAttribute("value");
            Assert.AreEqual(txtMedioExpected, txtMedioActualTexto);

            IWebElement txtMaximoActual = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("Maximo")));
            string txtMaximoActualTexto = txtMaximoActual.GetAttribute("value");
            Assert.AreEqual(txtMaximoExpected, txtMaximoActualTexto);

            //Regresar a lista de clases salariales
            IWebElement btnCancelar = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("btnCancelarClaseSalarial")));
            btnCancelar.Click();
        }


        // ------------------------------------------------------ EDITAR
        [Test, Order(2)]
        public void Editar_Clase_Salarial_Con_Informacion_Basica()
        {
            //Variables
            string txtDescripcionEditada = "DescripcionEditada";
            string txtCompaniaeditado = "2";
            string txtMinimoeditado = "2000";
            string txtMedioeditado = "2500";
            string txtMaximoeditado = "3000";

            //Editar clase salarial creada
            IWebElement txtBuscar = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("smlClaseSalarial_txtQuickSearch")));
            txtBuscar.SendKeys(txtDescripcionExpected);
            txtBuscar.SendKeys(Keys.Enter);
            txtBuscar.SendKeys(Keys.Enter);
            IWebElement tblRegistro = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='smlClaseSalarial_grid']/div[3]/table/tbody/tr")));
            actions.DoubleClick(tblRegistro).Perform();

            IWebElement txtDescripcion = driver.FindElement(By.Id("Descripcion"));
            txtDescripcion.Clear();
            txtDescripcion.SendKeys(txtDescripcionEditada);
            IWebElement cmbCompania = driver.FindElement(By.Id("CodigoCompania"));
            cmbCompania.Click();
            IWebElement Corporativo = driver.FindElement(By.XPath("//*[@id='CodigoCompania']/option[5]"));
            Corporativo.Click();
            IWebElement txtMinimo = driver.FindElement(By.Id("Minimo"));
            txtMinimo.Clear();
            txtMinimo.SendKeys(txtMinimoeditado);
            IWebElement txtMedio = driver.FindElement(By.Id("Medio"));
            txtMedio.Clear();
            txtMedio.SendKeys(txtMedioeditado);
            IWebElement txtMaximo = driver.FindElement(By.Id("Maximo"));
            txtMaximo.Clear();
            txtMaximo.SendKeys(txtMaximoeditado);
            IWebElement btnGuardar = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Name("btnGuardarClaseSalarial")));
            btnGuardar.Click();

        
            //Editar la clase salarial editada
            txtBuscar = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("smlClaseSalarial_txtQuickSearch")));
            txtBuscar.Clear();
            txtBuscar.SendKeys(txtDescripcionEditada);
            txtBuscar.SendKeys(Keys.Enter);
            txtBuscar.SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            IWebElement tblRegistroEditado = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='smlClaseSalarial_grid']/div[3]/table/tbody/tr")));
            tblRegistroEditado.Click();
            Thread.Sleep(1000);
            IWebElement btnEditar = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='smlClaseSalarial_edit']")));
            btnEditar.Click();

            //Verificaciones

            IWebElement txtDescripcionActual = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("Descripcion")));
            string txtDescripcionActualTexto = txtDescripcionActual.GetAttribute("value");
            Assert.AreEqual(txtDescripcionEditada, txtDescripcionActualTexto);

            IWebElement txtCompaniaActual = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("CodigoCompania")));
            string txtCompaniaTexto = txtCompaniaActual.GetAttribute("value");
            Assert.AreEqual(txtCompaniaeditado, txtCompaniaTexto);

            IWebElement txtMinimoActual = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("Minimo")));
            string txtMinimoActualTexto = txtMinimoActual.GetAttribute("value");
            Assert.AreEqual(txtMinimoeditado, txtMinimoActualTexto);

            IWebElement txtMedioActual = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("Medio")));
            string txtMedioActualTexto = txtMedioActual.GetAttribute("value");
            Assert.AreEqual(txtMedioeditado, txtMedioActualTexto);

            IWebElement txtMaximoActual = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("Maximo")));
            string txtMaximoActualTexto = txtMaximoActual.GetAttribute("value");
            Assert.AreEqual(txtMaximoeditado, txtMaximoActualTexto);

            //Regresar a lista de clases salariales
            IWebElement btnCancelar = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("btnCancelarClaseSalarial")));
            btnCancelar.Click();
        }


        // ------------------------------------------------------ GUARDAR DATOS EN BLANCO
        [Test, Order(3)]
        public void Guardar_Clase_Salarial_Con_Campos_En_Blanco()
        {
            //Inicialización de variables
            var txtErrorExpected = "La descripción es requerida";

            //Crear nueva clase salarial
            IWebElement btnNuevo = driver.FindElement(By.Id("smlClaseSalarial_new"));
            btnNuevo.Click();
            IWebElement btnGuardar = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Name("btnGuardarClaseSalarial")));
            btnGuardar.Click();

            //Verificaciones
            IWebElement msgError = driver.FindElement(By.XPath("//*[@id='MessagesAndErrors']/div"));
            Assert.AreEqual(txtErrorExpected, msgError.Text);

            //Regresar a lista de Clases salariales
            IWebElement btnCancelar = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("btnCancelarInstitucionEducativa")));
            btnCancelar.Click();
        }

        // -------------------------------------------------------- CONSULTAR
        

        // --------------------------------Eliminar una Institución Educativa

        public void Login(string username, string password)
        {
            IWebElement inputUser = driver.FindElement(By.Id("txtUsername"));
            inputUser.SendKeys(username);
            IWebElement inputPassword = driver.FindElement(By.Id("txtPassword"));
            inputPassword.SendKeys(password);
            inputPassword.SendKeys(Keys.Enter);
        }
        public void Logout()
        {
            IWebElement CerrarSesion = driver.FindElement(By.XPath("//*[@id='topmenu']/a[1]"));
            CerrarSesion.Click();
        }


    }

}