using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Reflection;
using SKSBUsinessModel;

/// <summary>
/// Summary description for BusinessFacadLayer
/// </summary>
public class BusinessFacadLayer
{
    DataTable dtRecords;
    SKSEntities objSKSEntities;
    List<tbl_BillDetails> objListBillDetails;
    List<tbl_BillDetails_temp> objListBillDetails_Temp;
    List<tbl_CompanyMaster> objListCompanyMaster;
    List<tbl_ProductMaster> objListProductMaster;
    List<vw_ProductMaster> objvwProductMaster;
    List<tbl_ProductPrice> objListProductPriceMaster;
    List<vw_BillingCustomer> objListBillingCustomer;
    List<vw_ShippingCustomer> objListShippingCustomer;
    List<tbl_CustomerBillingAddress> objListCustomerBillingAddress;
    List<tbl_CustomerShippingAddress> objListCustomerShippingAddress;
    tbl_BillMaster objBillMaster;
    tbl_BillDetails objBillDetails;
    List<tbl_TransportationMaster> objTransposrationList;
    List<tbl_BillMaster> objLIstBillMaster;
    private tbl_CompanyMaster objCompanyMaster;
    private tbl_ProductMaster objProductMaster;
    private tbl_ProductPrice objProductPrice;
    DataSet dsRecord;
    List<tbl_SKSDetails> objListStoreDetails;
    List<vw_BillInvoiceMaster> objListvw_BillInvoiceMaster;
    List<vw_Bill_InvoiceDetails> objListvw_Bill_InvoiceDetails;
    List<tbl_Users> objListUsers;
    List<vw_ProductPrice> objListvw_vw_ProductPrice;

    private int isExist = 0;



    public BusinessFacadLayer()
    {

    }

    public DataTable getBillDetails(Int64 BillMasterID)
    {
        try
        {
            dtRecords = new DataTable();
            objSKSEntities = new SKSEntities();
            objListBillDetails = (from BillDetails in objSKSEntities.tbl_BillDetails where (BillDetails.IsActive == true && BillDetails.IsDeleted == false) select BillDetails).ToList();
            dtRecords = ToDataTable<tbl_BillDetails>(objListBillDetails);
            return dtRecords;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dtRecords.Dispose();
            objSKSEntities = null;
        }
    }

    public DataTable getBillingCustomerList()
    {
        try
        {
            dtRecords = new DataTable();
            objSKSEntities = new SKSEntities();
            objListBillingCustomer = (from BillingCustomer in objSKSEntities.vw_BillingCustomer select BillingCustomer).ToList();
            dtRecords = ToDataTable<vw_BillingCustomer>(objListBillingCustomer);
            return dtRecords;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dtRecords.Dispose();
            objSKSEntities = null;
        }
    }

    public DataTable getShippingCustomerList()
    {
        try
        {
            dtRecords = new DataTable();
            objSKSEntities = new SKSEntities();
            objListShippingCustomer = (from ShippingCustomer in objSKSEntities.vw_ShippingCustomer select ShippingCustomer).ToList();
            dtRecords = ToDataTable<vw_ShippingCustomer>(objListShippingCustomer);
            return dtRecords;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dtRecords.Dispose();
            objSKSEntities = null;
        }
    }

    public DataSet getInvoiceDetails(Int64 InvoiceNo, int PagingSize, int PageNo)
    {
        try
        {
            dtRecords = new DataTable();
            objSKSEntities = new SKSEntities();

            objListStoreDetails = (from StoreDetails in objSKSEntities.tbl_SKSDetails where (StoreDetails.IsActive == true && StoreDetails.IsDeleted == false) select StoreDetails).ToList();
            dtRecords = ToDataTable<tbl_SKSDetails>(objListStoreDetails);

            dsRecord = new DataSet();
            dsRecord.Tables.Add(dtRecords.Copy());
            dtRecords.Clear();

            objListvw_BillInvoiceMaster = (from BillInvoiceMaster in objSKSEntities.vw_BillInvoiceMaster where BillInvoiceMaster.InvoiceID == InvoiceNo select BillInvoiceMaster).ToList();
            dtRecords = ToDataTable<vw_BillInvoiceMaster>(objListvw_BillInvoiceMaster);

            dsRecord.Tables.Add(dtRecords.Copy());
            dtRecords.Clear();

            objListvw_Bill_InvoiceDetails = (from InvoiceDetails in objSKSEntities.vw_Bill_InvoiceDetails where InvoiceDetails.InvoiceNo == InvoiceNo select InvoiceDetails).ToList();
            dtRecords = ToDataTable<vw_Bill_InvoiceDetails>(objListvw_Bill_InvoiceDetails);

            dsRecord.Tables.Add(dtRecords.Copy());
            dtRecords.Clear();

            return dsRecord;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dtRecords.Dispose();
            objSKSEntities = null;
        }
    }

    public DataTable getBillingSearchCustomerDetailinForm(Int32 BillingSearchCustomerID)
    {
        try
        {
            dtRecords = new DataTable();
            objSKSEntities = new SKSEntities();
            objListCustomerBillingAddress = (from CustomerBillingAddress in objSKSEntities.tbl_CustomerBillingAddress where CustomerBillingAddress.Id == BillingSearchCustomerID select CustomerBillingAddress).ToList();
            dtRecords = ToDataTable<tbl_CustomerBillingAddress>(objListCustomerBillingAddress);
            return dtRecords;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dtRecords.Dispose();
            objSKSEntities = null;
            objListCustomerBillingAddress = null;
        }
    }

    public DataTable getShippingSearchCustomerDetailinForm(Int32 ShippingSearchCustomerID)
    {
        try
        {
            dtRecords = new DataTable();
            objSKSEntities = new SKSEntities();
            objListCustomerShippingAddress = (from CustomerShippingAddress in objSKSEntities.tbl_CustomerShippingAddress where CustomerShippingAddress.Id == ShippingSearchCustomerID select CustomerShippingAddress).ToList();
            dtRecords = ToDataTable<tbl_CustomerShippingAddress>(objListCustomerShippingAddress);
            return dtRecords;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dtRecords.Dispose();
            objSKSEntities = null;
            objListCustomerShippingAddress = null;
        }
    }
    public DataTable getStateMaster()
    {
        try
        {
            dtRecords = new DataTable();
            objSKSEntities = new SKSEntities();
            objListBillingCustomer = (from BillingCustomer in objSKSEntities.vw_BillingCustomer select BillingCustomer).ToList();
            dtRecords = ToDataTable<vw_BillingCustomer>(objListBillingCustomer);
            return dtRecords;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dtRecords.Dispose();
            objSKSEntities = null;
        }
    }

    public DataTable getBillMasterList(Int64 InvoiceID)
    {
        try
        {
            dtRecords = new DataTable();
            objSKSEntities = new SKSEntities();
            objLIstBillMaster = (from BillMaster in objSKSEntities.tbl_BillMaster where (BillMaster.IsActive == true && BillMaster.IsDeleted == false) select BillMaster).ToList();
            dtRecords = ToDataTable<tbl_BillMaster>(objLIstBillMaster);
            return dtRecords;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dtRecords.Dispose();
            objSKSEntities = null;
        }
    }

    public DataTable getBillDetails_Temp(string GUID)
    {
        try
        {
            dtRecords = new DataTable();
            objSKSEntities = new SKSEntities();
            objListBillDetails_Temp = (from BillDetails in objSKSEntities.tbl_BillDetails_temp where (BillDetails.IsActive == true && BillDetails.IsDeleted == false && BillDetails.GUID == GUID) select BillDetails).ToList();
            dtRecords = ToDataTable<tbl_BillDetails_temp>(objListBillDetails_Temp);
            return dtRecords;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dtRecords.Dispose();
            objSKSEntities = null;
        }
    }
    public DataTable getCompanyMaster()
    {
        try
        {
            dtRecords = new DataTable();
            objSKSEntities = new SKSEntities();
            objListCompanyMaster = (from CompanyMaster in objSKSEntities.tbl_CompanyMaster where (CompanyMaster.IsDeleted == false) select CompanyMaster).ToList();
            dtRecords = ToDataTable<tbl_CompanyMaster>(objListCompanyMaster);
            return dtRecords;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dtRecords.Dispose();
            objSKSEntities = null;
        }
    }

    public int AddCompany(tbl_CompanyMaster objCompanyMaster)
    {

        try
        {
            isExist = 0;
            dtRecords = new DataTable();
            objSKSEntities = new SKSEntities();
            isExist = (from CompanyMaster in objSKSEntities.tbl_CompanyMaster where (CompanyMaster.Name == objCompanyMaster.Name && CompanyMaster.IsDeleted == false) select CompanyMaster.Id).SingleOrDefault(); ;
            if (isExist > 0)
            {
                return isExist;
            }
            else
            {
                objSKSEntities.tbl_CompanyMaster.Add(objCompanyMaster);
                objSKSEntities.SaveChanges();
                return isExist;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dtRecords.Dispose();
        }
    }
    public int AddProduct(tbl_ProductMaster objProductMaster)
    {

        try
        {
            isExist = 0;
            dtRecords = new DataTable();
            objSKSEntities = new SKSEntities();
            isExist = (from ProductMaster in objSKSEntities.tbl_ProductMaster where (ProductMaster.FK_CompanyMasterID == objProductMaster.FK_CompanyMasterID && ProductMaster.ProductName == objProductMaster.ProductName && ProductMaster.IsDeleted == false) select ProductMaster.Id).SingleOrDefault(); ;
            if (isExist > 0)
            {
                return isExist;
            }
            else
            {
                objSKSEntities.tbl_ProductMaster.Add(objProductMaster);
                objSKSEntities.SaveChanges();
                return isExist;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dtRecords.Dispose();
        }
    }

    public int AddProductPrice(tbl_ProductPrice objProductPrice)
    {

        try
        {
            isExist = 0;
            dtRecords = new DataTable();
            objSKSEntities = new SKSEntities();
            isExist = (from ProductPrice in objSKSEntities.tbl_ProductPrice where (ProductPrice.FK_ProductMasterID == objProductPrice.FK_ProductMasterID && ProductPrice.IsDeleted == false) select ProductPrice.Id).SingleOrDefault(); ;
            if (isExist > 0)
            {
                return isExist;
            }
            else
            {
                objSKSEntities.tbl_ProductPrice.Add(objProductPrice);
                objSKSEntities.SaveChanges();
                return isExist;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dtRecords.Dispose();
        }
    }
    public DataTable getProductMaster(int CompanyID)
    {
        try
        {
            dtRecords = new DataTable();
            objSKSEntities = new SKSEntities();
            objvwProductMaster = (from ProductMaster in objSKSEntities.vw_ProductMaster select ProductMaster).ToList();
            dtRecords = ToDataTable<vw_ProductMaster>(objvwProductMaster);
            return dtRecords;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dtRecords.Dispose();
            objSKSEntities = null;
            objListProductMaster = null;
        }
    }

    public DataTable getProductMaster(int CompanyID, int ProductID)
    {
        try
        {
            dtRecords = new DataTable();
            objSKSEntities = new SKSEntities();
            objListProductMaster = (from ProductMaster in objSKSEntities.tbl_ProductMaster where (ProductMaster.IsActive == true && ProductMaster.IsDeleted == false && ProductMaster.FK_CompanyMasterID == CompanyID && ProductMaster.Id == ProductID) select ProductMaster).ToList();
            dtRecords = ToDataTable<tbl_ProductMaster>(objListProductMaster);
            return dtRecords;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dtRecords.Dispose();
            objSKSEntities = null;
            objListProductMaster = null;
        }
    }
    public DataTable getProductPrice(int ProductID)
    {
        try
        {
            dtRecords = new DataTable();
            objSKSEntities = new SKSEntities();

            objListProductPriceMaster = (from ProductPrice in objSKSEntities.tbl_ProductPrice where (ProductPrice.IsActive == true && ProductPrice.IsDeleted == false && ProductPrice.FK_ProductMasterID == ProductID) select ProductPrice).ToList();

            dtRecords = ToDataTable<tbl_ProductPrice>(objListProductPriceMaster);
            return dtRecords;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dtRecords.Dispose();
            objSKSEntities = null;
            objListProductPriceMaster = null;
        }
    }

    public DataTable getProductPriceList()
    {
        try
        {
            dtRecords = new DataTable();
            objSKSEntities = new SKSEntities();

           objListvw_vw_ProductPrice = (from ProductPrice in objSKSEntities.vw_ProductPrice select ProductPrice).ToList();
          
            dtRecords = ToDataTable<vw_ProductPrice>(objListvw_vw_ProductPrice);
            return dtRecords;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dtRecords.Dispose();
            objSKSEntities = null;
            objListvw_vw_ProductPrice = null;
        }
    }

    public DataTable getTransposrationList()
    {
        try
        {
            dtRecords = new DataTable();
            objSKSEntities = new SKSEntities();
            objTransposrationList = (from TransposrationList in objSKSEntities.tbl_TransportationMaster where (TransposrationList.IsActive == true && TransposrationList.IsDeleted == false) select TransposrationList).ToList();
            dtRecords = ToDataTable<tbl_TransportationMaster>(objTransposrationList);
            return dtRecords;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dtRecords.Dispose();
            objSKSEntities = null;
            objListProductPriceMaster = null;
        }
    }

    public DataTable ToDataTable<T>(List<T> items)
    {
        DataTable dataTable = new DataTable(typeof(T).Name);

        //Get all the properties
        PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (PropertyInfo prop in Props)
        {
            //Setting column names as Property names
            dataTable.Columns.Add(prop.Name);
        }
        foreach (T item in items)
        {
            var values = new object[Props.Length];
            for (int i = 0; i < Props.Length; i++)
            {
                //inserting property values to datatable rows
                values[i] = Props[i].GetValue(item, null);
            }
            dataTable.Rows.Add(values);
        }
        //put a breakpoint here and check datatable
        return dataTable;
    }

    public void AddItemInBillDetailsTemp(tbl_BillDetails_temp objtbl_BillDetails_temp)
    {
        try
        {
            objSKSEntities = new SKSEntities();
            objSKSEntities.tbl_BillDetails_temp.Add(objtbl_BillDetails_temp);
            objSKSEntities.SaveChanges();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objSKSEntities = null;
        }
    }

    public void AddBillingCustomerDetails(tbl_CustomerBillingAddress objCustomerBillingAddress)
    {
        try
        {
            objSKSEntities = new SKSEntities();
            objSKSEntities.tbl_CustomerBillingAddress.Add(objCustomerBillingAddress);
            objSKSEntities.SaveChanges();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objSKSEntities = null;
        }
    }

    public void AddShippingCustomerDetails(tbl_CustomerShippingAddress objCustomerShippingAddress)
    {
        try
        {
            objSKSEntities = new SKSEntities();
            objSKSEntities.tbl_CustomerShippingAddress.Add(objCustomerShippingAddress);
            objSKSEntities.SaveChanges();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objSKSEntities = null;
        }
    }

    public void DeleteItemInBillDetailsTemp(Int64 TempBillDetailsID, string GUID)
    {
        try
        {
            objSKSEntities = new SKSEntities();

            var itemToRemove = objSKSEntities.tbl_BillDetails_temp.SingleOrDefault(x => x.Id == TempBillDetailsID && x.GUID == GUID); //returns a single item.

            if (itemToRemove != null)
            {
                objSKSEntities.tbl_BillDetails_temp.Remove(itemToRemove);
                objSKSEntities.SaveChanges();
            }


        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objSKSEntities = null;
        }
    }

    public void DeleteorEnableDisableCompany(int CompanyID, bool blnTrueFalse, bool blnDelete)
    {
        try
        {

            objSKSEntities = new SKSEntities();

            objCompanyMaster = objSKSEntities.tbl_CompanyMaster.SingleOrDefault(x => x.Id == CompanyID); //returns a single item.

            if (objCompanyMaster != null)
            {
                objCompanyMaster.IsActive = blnTrueFalse;
                objCompanyMaster.IsDeleted = blnDelete;
                objSKSEntities.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objSKSEntities = null;
        }
    }

    public void DeleteorEnableDisableCompanyProduct(int ProductID, bool blnTrueFalse, bool blnDelete)
    {
        try
        {

            objSKSEntities = new SKSEntities();

            objProductMaster = objSKSEntities.tbl_ProductMaster.SingleOrDefault(x => x.Id == ProductID); //returns a single item.

            if (objProductMaster != null)
            {
                objProductMaster.IsActive = blnTrueFalse;
                objProductMaster.IsDeleted = blnDelete;
                objSKSEntities.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objSKSEntities = null;
            objProductMaster = null;
        }
    }

    public void DeleteorEnableDisableCompanyProductPrice(int ProductID, bool blnTrueFalse, bool blnDelete)
    {
        try
        {

            objSKSEntities = new SKSEntities();

            objProductPrice = objSKSEntities.tbl_ProductPrice.SingleOrDefault(x => x.Id == ProductID); //returns a single item.

            if (objProductPrice != null)
            {
                objProductPrice.IsActive = blnTrueFalse;
                objProductPrice.IsDeleted = blnDelete;
                objSKSEntities.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objSKSEntities = null;
            objProductPrice = null;
        }
    }

    public Int64 CreateInvoicenGenerateInvoiceNo(tbl_BillMaster objBillMaster)
    {
        try
        {
            objSKSEntities = new SKSEntities();
            objSKSEntities.tbl_BillMaster.Add(objBillMaster);
            objSKSEntities.SaveChanges();
            return objBillMaster.BillId;

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objSKSEntities = null;
        }
    }
    public void AddBillDetails(tbl_BillDetails objBillDetails)
    {
        try
        {
            objSKSEntities = new SKSEntities();
            objSKSEntities.tbl_BillDetails.Add(objBillDetails);
            objSKSEntities.SaveChanges();


        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objSKSEntities = null;
        }
    }

    public DataTable getUserLoginDetail(string UserName, string Password)
    {
        try
        {
            dtRecords = new DataTable();
            objSKSEntities = new SKSEntities();
            objListUsers = (from Users in objSKSEntities.tbl_Users where (Users.IsDeleted == false && Users.UserName == UserName && Users.Password == Password) select Users).ToList();
            dtRecords = ToDataTable<tbl_Users>(objListUsers);
            return dtRecords;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dtRecords.Dispose();
            objSKSEntities = null;
            objListUsers = null;
        }
    }

    //public DataTable getUserLoginDetail(string UserName, string Password)
    //{
    //    try
    //    {
    //        dtRecords = new DataTable();
    //        objSKSEntities = new SKSEntities();
    //        objListUsers = (from Users in objSKSEntities.tbl_Users where (Users.IsDeleted == false && Users.UserName == UserName && Users.Password == Password) select Users).ToList();
    //        dtRecords = ToDataTable<tbl_Users>(objListUsers);
    //        return dtRecords;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {
    //        dtRecords.Dispose();
    //        objSKSEntities = null;
    //        objListUsers = null;
    //    }
    //}
}