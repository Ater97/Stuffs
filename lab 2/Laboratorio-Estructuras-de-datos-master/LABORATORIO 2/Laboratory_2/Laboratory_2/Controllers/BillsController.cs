﻿ using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laboratory_2.UtilitiesClass;
using Laboratory_2.Models;
using System.IO;

namespace Laboratory_2.Controllers
{
    public class BillsController : Controller
    {
        // GET: Bills
        public ActionResult Index()
        {
            ViewBag.Message = "Cantidad de Facturas: " + Singleton.Instance.BillsBinaryTree.GetCount();
            List<BillsModel> mostrar = Singleton.Instance.BillsBinaryTree.InOrden();
            return View(mostrar);
        }
        [HttpPost]
        public ActionResult Search(string serie, string correlative)
        {
            try
            {
                BillsModel temp = SearchElement((serie + "|" + correlative).Trim());

                if (temp == null)
                {
                    ViewBag.Message = "Cantidad de elementos: " + Singleton.Instance.BillsBinaryTree.GetCount();
                    ViewBag.Error = "Error";
                    ViewBag.Error1 = "El elemento buscado no se ha encontrado en la base de datos.";
                    ViewBag.Error2 = "Vuelva a intentarlo de nuevo.";
                    return View("Index", Singleton.Instance.BillsBinaryTree);
                }
                return View("Details", temp);
            }
            catch
            {
                return View("Index");
            }
        }
        public ActionResult UploadBillDescription()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadBillDescription(HttpPostedFileBase file)
        {
            try
            {
                if (Singleton.Instance.flags[0] && Singleton.Instance.flags[1])
                {
                    if (file == null) { ViewBag.Message = "Ocurrió un error. Por favor seleccione un archivo."; return View("UploadBillDescription"); }
                    BinaryReader b = new BinaryReader(file.InputStream);
                    byte[] binData = b.ReadBytes(file.ContentLength);

                    string Data = System.Text.Encoding.UTF8.GetString(binData);
                    Data = Data.Replace("\",\"", "*");
                    Data = Data.Replace("\r\n", "*");
                    Data = Data.Replace('"', ' ');
                    string[] Result = Data.Split('*');
                    for (int i = 0; i < VerverifyLenght(Result.Length, 4); i = i + 4)
                    {
                        string serie = Result[i] + "|";
                        int correlative = int.Parse(Result[i + 1]);
                        string[] newIDs = { Result[i + 2] };
                        double newTotal = double.Parse(Result[i + 3]);

                        try
                        {
                            BillsModel newBill = AddDescription(serie, correlative, newIDs, newTotal);
                            Singleton.Instance.BillsBinaryTree.Edit<string>(Comparar, serie + correlative, newBill);
                        }
                        catch
                        {
                            ViewBag.Message = "serie + correlative  ";
                        }
                    }
                    ViewBag.Message = "ERROR con:" + ViewBag.Message;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = "Ocurrió un error al subir el archivo, por favor revise que los productos se encuentren disponibles. ";
                    return RedirectToAction("UploadBillDescription");
                }
            }
            catch(Exception e)
            {
                ViewBag.Message = "Error: " + e.Message;
                return View();
            }
        }

        public ActionResult UploadBill()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UploadBill(HttpPostedFileBase file)
        {
            try
            {
                if (file == null) { ViewBag.Message = "Ocurrió un error. Por favor seleccione un archivo"; return View("UploadBill"); }
                BinaryReader b = new BinaryReader(file.InputStream);
                byte[] binData = b.ReadBytes(file.ContentLength);

                string Data = System.Text.Encoding.UTF8.GetString(binData);
                Data = Data.Replace("\",\"", "*");
                Data = Data.Replace("\r\n", "*");
                Data = Data.Replace('"', ' ');
                string[] Result = Data.Split('*');
                for (int i = 0; i < VerverifyLenght(Result.Length, 5); i = i + 5)
                {
                    string[] description = { "Descripcion pendiente" };
                    BillsModel newBill = (new BillsModel
                    {
                        Serie = Result[i] + "|",
                        Correlative = int.Parse(Result[i + 1]),
                        Name = Result[i + 2],
                        NIT = Result[i + 3],
                        SaleDate = Result[i + 4],
                        BillDescription = description,
                        Total = 00.00
                    });
                    Singleton.Instance.BillsBinaryTree.Add(newBill);
                }
                Singleton.Instance.flags[1] = true;
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Message = "Ocurrió un error al subir el archivo, por favor revise el formato.";
                return View();
            }
        }


        public ActionResult UploadBillPablo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadBillPablo(HttpPostedFileBase file)
        {
            try
            {
                if (file == null) { ViewBag.Message = "Ocurrió un error. Por favor seleccione un archivo"; return View("UploadBillPablo"); }
                BinaryReader b = new BinaryReader(file.InputStream);
                byte[] binData = b.ReadBytes(file.ContentLength);

                string Data = System.Text.Encoding.UTF8.GetString(binData);
                Data = Data.Replace("\r\n", ",");
                string[] Result = Data.Split(',');
                for (int i = 0; i < VerverifyLenght(Result.Length,7); i = i + 7)
                {
                    BillsModel newBill = (new BillsModel
                    {
                        Serie = Result[i] + "|",
                        Correlative = int.Parse(Result[i + 1]),
                        Name = Result[i + 2],
                        NIT = Result[i + 3],
                        SaleDate = Result[i + 4],
                        BillDescription = new string[] { Result[i + 5] },
                        Total = double.Parse(Result[i + 6])
                    });

                        Singleton.Instance.BillsBinaryTree.Add(CheckDescriptionPablo(newBill));
                        //Singleton.Instance.BillsBinaryTree.Add(newBill);
                }

                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                ViewBag.Message = e.Message;
                return View();
            }
        }

        // GET: Bills/Details/5
        public ActionResult Details(string id)
        {
            return View(SearchElement(id.Trim()));
        }

        // GET: Bills/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bills/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                if (Singleton.Instance.flags[0])
                {
                    // TODO: Add insert logic here
                    string[] des = { "Descripcion pendiente" };
                    BillsModel newBillModel = (new BillsModel
                    {
                        Serie = (collection["Serie"]) + "|",
                        Correlative = int.Parse(collection["Correlative"]),
                        Name = collection["Name"],
                        NIT = collection["NIT"],
                        SaleDate = collection["SaleDate"],
                        BillDescription = des,
                        Total = 00,
                    });
                    Singleton.Instance.BillsBinaryTree.Add(newBillModel);
                    Singleton.Instance.TempBillId = (collection["Serie"]) + "|" + (collection["Correlative"]);
                    return RedirectToAction("MultiSelectProduct");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }
      
       

        public ActionResult  MultiSelectProduct()
        {
            ViewBag.Productslist = GetProducts(null);

            return View();
        }

        [HttpPost]
        public ActionResult MultiSelectProduct(FormCollection form)
        {
            try
            {
                ViewBag.Message = "Cantidad de Productos: " + Singleton.Instance.ProductsBinaryTree.GetCount();
                ViewBag.YouSelected = form["Products"];
                string selectedValues = form["Products"];
                ViewBag.Productslist = GetProducts(selectedValues.Split(','));
                string[] idProducts = ViewBag.Productslist.SelectedValues;
                string[] newDescription = new string[idProducts.Count<string>()];
                double newTotal = 1;
                BillsModel newBill = SearchElement(Singleton.Instance.TempBillId.Trim());
                for (int i = 0; i < idProducts.Count<string>(); i++)
                {
                    ProductModel newProduct = SearchProduct(idProducts[i].Trim());
                    newDescription[0] = newProduct.ProductID;
                    
                    string[] idbill = Singleton.Instance.TempBillId.Split('|');
                    newBill = AddDescription(idbill[0] + "|", int.Parse(idbill[1]), newDescription, newTotal);
                    Singleton.Instance.BillsBinaryTree.Edit<string>(Comparar, Singleton.Instance.TempBillId, newBill);
                }
                Singleton.Instance.TempBillId = "";
            }
            catch
            {
                return View("Create");
            }
            return RedirectToAction("Index");
        }

        public MultiSelectList GetProducts(string[] selectedValues)
        {
            List<ProductModel> Products = Singleton.Instance.ProductsBinaryTree.InOrden();
            //List<ProductModel> Products = new List<ProductModel>()
            //{
            //    new ProductModel() { ProductID = "Id1", ProductDescription="des1",ProductPrize = 11,ProductCount=11 },

            //    new ProductModel() { ProductID = "Id2", ProductDescription="des2",ProductPrize = 12,ProductCount=12},

            //    new ProductModel() { ProductID = "Id3", ProductDescription="des3",ProductPrize = 13,ProductCount=13},

            //    new ProductModel() {ProductID = "Id4", ProductDescription="des4",ProductPrize = 14,ProductCount=14 },

            //    new ProductModel() { ProductID = "Id15", ProductDescription="des15",ProductPrize = 15,ProductCount=15 }
            //};

            return new MultiSelectList(Products, "ProductID", "MultiInformation", selectedValues);

        }

        // GET: Bills/Edit/5
        //public ActionResult Edit(string id)
        //{
        //    return View(SearchElement(id));
        //}

        //// POST: Bills/Edit/5
        //[HttpPost]
        //public ActionResult Edit(string id, FormCollection collection)
        //{
        //    try
        //    {
        //        ViewBag.Message = "Si desea ingresar mas de un produto en la descripion: separelos por *";
        //        string[] SerieandCorrelative = id.Split('|');
        //        BillsModel Bill = (new BillsModel
        //            {
        //            Serie = SerieandCorrelative[0],
        //            Correlative = int.Parse(SerieandCorrelative[1]),
        //            Name = collection["Name"],
        //            NIT = collection["NIT"],
        //            BillDescription = (collection["BillDescription"].Trim().Split('*')),
        //            Total = double.Parse(collection["Total"]), 
        //        });

        //        if (Singleton.Instance.BillsBinaryTree.Edit<string>(Comparar, id, Bill))
        //        {
        //            ViewBag.Message = "Se ha editado el elemento correctamente.";
        //        }
        //        else
        //        {
        //            ViewBag.Message = "Ha ocurrido un error, no se han realizado los cambios en el elemento deseado.";
        //        }

        //        return RedirectToAction("Index");
        //    }
        //    catch (Exception e)
        //    {
        //        ViewBag.Message = "ERROR: " + e.Message;
        //        return RedirectToAction("Index");
        //    }
        //}

        // GET: Bills/Delete/5
        public ActionResult Delete(string id)
        {
            return View(SearchElement(id.Trim()));
        }

        // POST: Bills/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                DeleteBill(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private bool DeleteBill(string id)
        {
            TreeNode<BillsModel> Bill = Singleton.Instance.BillsBinaryTree.Search<string>(Comparar, id.Trim());
            Singleton.Instance.BillsBinaryTree.Eliminate(Bill);
            return false;
        }

        private double VerverifyLenght(double number,int limit)
        {
            if (number % limit == 0)
            {
                return number;
            }
            else
            {
                return (VerverifyLenght(number - 1, limit));
            }
        }

        public static int Comparar<E>(BillsModel product, E elementoBuscar)
        {
            string aux = product.Serie + product.Correlative.ToString();
            aux = aux.Trim();
            return aux.CompareTo(elementoBuscar);
        }

        public BillsModel SearchElement(string id)
        {
            TreeNode<BillsModel> temp = Singleton.Instance.BillsBinaryTree.Search<string>(Comparar, id);
            return temp.Value;
        }

        public ProductModel SearchProduct(string id)
        {
            TreeNode<ProductModel> temp = Singleton.Instance.ProductsBinaryTree.Search<string>(CompararProducto, id);
            return temp.Value;
        }

        public static int CompararProducto<E>(ProductModel product, E elementoBuscar)
        {
            return product.ProductID.CompareTo(elementoBuscar);
        }

        public BillsModel AddDescription(string serie, int correlative, string[] ID, double total)
        {
            
            BillsModel newBill = SearchElement((serie + correlative).Trim());
            ProductModel tempProduct = SearchProduct(ID[0].Trim());
            int lenght = newBill.BillDescription.Length;
            string[] newDescription = new string[lenght + 1];
            for (int i = 0; i < lenght; i++)
            {
                newDescription[i] = newBill.BillDescription[i] + ", ";
            }
            if (tempProduct != null && tempProduct.ProductCount > 0 && tempProduct.ProductCount >= total)
            {
                tempProduct.ProductCount = tempProduct.ProductCount - total;
                Singleton.Instance.ProductsBinaryTree.Edit<string>(CompararProducto, tempProduct.ProductID, tempProduct);
                if (newBill.BillDescription[0] == "Descripcion pendiente")
                {
                    newBill.BillDescription[0] = tempProduct.ProductDescription + " X " + total;
                }
                else
                {
                    newDescription[lenght] = tempProduct.ProductDescription + " X " + total;
                    newBill.BillDescription = newDescription;
                }
                newBill.Total += total * tempProduct.ProductPrize;
            }
            else
            {
                newDescription[lenght] = "Error: no se encontraron suficientes productos en el inventario" ;
                newBill.BillDescription = newDescription;
            }

            return newBill;
        }

        public BillsModel CheckDescriptionPablo(BillsModel newBill)
        {

            int lenght = newBill.BillDescription.Length;
            string[] newDescription = new string[lenght + 1];
            try
            {
                ProductModel tempProduct = SearchProduct(newBill.BillDescription[0].Trim());
                if (tempProduct != null && tempProduct.ProductCount > 0)
                {
                    tempProduct.ProductCount--;
                    Singleton.Instance.ProductsBinaryTree.Edit<string>(CompararProducto, tempProduct.ProductID, tempProduct);
                    newBill.BillDescription[0] = tempProduct.ProductDescription + " X " + tempProduct.ProductPrize.ToString();
                }
                else
                {
                    newDescription[0] = "Error: no se encontraron suficientes productos en el inventario";
                    newBill.BillDescription = newDescription;
                    newBill.Total = 0;
                }
            }
            catch
            {
                newDescription[0] = "Error: no se encontraron suficientes productos en el inventario";
                newBill.BillDescription = newDescription;
                newBill.Total = 0;
            }

            return newBill;
        }


    }
}
