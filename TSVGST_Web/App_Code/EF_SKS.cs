﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

public partial class tbl_BillDetails
{
    public long Id { get; set; }
    public long FK_BillMasterID { get; set; }
    public string HSNNo { get; set; }
    public int Qnty { get; set; }
    public decimal Rate { get; set; }
    public string UOM { get; set; }
    public decimal Total { get; set; }
    public decimal Discount { get; set; }
    public decimal TaxableValue { get; set; }
    public decimal SGSTRate { get; set; }
    public decimal SGSTValue { get; set; }
    public decimal CGSTRate { get; set; }
    public decimal CGSTValue { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public string CreatedBy { get; set; }
    public Nullable<System.DateTime> CreatedOn { get; set; }
    public string UpdatedBy { get; set; }
    public Nullable<System.DateTime> UpdatedOn { get; set; }
    public int CompanyID { get; set; }
    public int ProductID { get; set; }
    public string GUID { get; set; }
}

public partial class tbl_BillDetails_Other
{
    public long Id { get; set; }
    public long FK_BillMasterID { get; set; }
    public Nullable<decimal> FreightCharges { get; set; }
    public Nullable<decimal> LoadingnPackingCharges { get; set; }
    public Nullable<decimal> INsuranceCharges { get; set; }
    public Nullable<decimal> OtherCharges { get; set; }
    public Nullable<bool> IsActive { get; set; }
    public Nullable<bool> IsDeleted { get; set; }
    public string CreatedBy { get; set; }
    public Nullable<System.DateTime> CreatedOn { get; set; }
    public string UpdatedBy { get; set; }
    public Nullable<System.DateTime> UpdatedOn { get; set; }
}

public partial class tbl_BillDetails_temp
{
    public long Id { get; set; }
    public string HSNNo { get; set; }
    public Nullable<int> Qnty { get; set; }
    public Nullable<decimal> Rate { get; set; }
    public string UOM { get; set; }
    public Nullable<decimal> Total { get; set; }
    public Nullable<decimal> Discount { get; set; }
    public Nullable<decimal> TaxableValue { get; set; }
    public Nullable<decimal> SGSTRate { get; set; }
    public Nullable<decimal> SGSTValue { get; set; }
    public Nullable<decimal> CGSTRate { get; set; }
    public Nullable<decimal> CGSTValue { get; set; }
    public Nullable<bool> IsActive { get; set; }
    public Nullable<bool> IsDeleted { get; set; }
    public string GUID { get; set; }
    public string CreatedBy { get; set; }
    public Nullable<System.DateTime> CreatedOn { get; set; }
    public string UpdatedBy { get; set; }
    public Nullable<System.DateTime> UpdatedOn { get; set; }
    public int CompanyID { get; set; }
    public int ProductID { get; set; }
    public string Company { get; set; }
    public string Product { get; set; }
}

public partial class tbl_BillMaster
{
    public long BillId { get; set; }
    public string FinancialYear { get; set; }
    public System.DateTime InvoiceDate { get; set; }
    public int FK_BillingCustomerID { get; set; }
    public int FK_ShippingCustomerID { get; set; }
    public decimal InvoiceTotalAmount { get; set; }
    public decimal TotalDiscountonInvoice { get; set; }
    public decimal TotalCollectedAmount { get; set; }
    public Nullable<decimal> FreightCharges { get; set; }
    public Nullable<decimal> LoadingnPackingCharges { get; set; }
    public Nullable<decimal> InsuranceCharges { get; set; }
    public Nullable<decimal> OtherCharges { get; set; }
    public string TransportationMode { get; set; }
    public string VehivleNumber { get; set; }
    public Nullable<System.DateTime> DateNSupplyofTime { get; set; }
    public string PlaceofSupply { get; set; }
    public string InvoiceStatus { get; set; }
    public string GUID { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public string CreatedBy { get; set; }
    public Nullable<System.DateTime> CreatedOn { get; set; }
    public string UpdatedBy { get; set; }
    public Nullable<System.DateTime> UpdatedOn { get; set; }
    public Nullable<decimal> TotalTaxableAmount { get; set; }
    public Nullable<decimal> TotalSGSTAmount { get; set; }
    public Nullable<decimal> TotalCGSTAmount { get; set; }
    public Nullable<int> TotalProductQuantity { get; set; }
}

public partial class tbl_CompanyMaster
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string MobileNo { get; set; }
    public string BusinessWebsite { get; set; }
    public string CompanyShortKey { get; set; }
    public string ContactPersonName { get; set; }
    public Nullable<bool> IsActive { get; set; }
    public Nullable<bool> IsDeleted { get; set; }
    public string CreatedBy { get; set; }
    public Nullable<System.DateTime> CreatedOn { get; set; }
    public string UpdatedBy { get; set; }
    public Nullable<System.DateTime> UpdatedOn { get; set; }
}

public partial class tbl_CustomerBillingAddress
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public string BillingAddress1 { get; set; }
    public string BillingAddress2 { get; set; }
    public string BillingCity { get; set; }
    public Nullable<int> FK_StateID { get; set; }
    public string Billingpin { get; set; }
    public string BillingEmail { get; set; }
    public string BillingPhone { get; set; }
    public string BillingPANNo { get; set; }
    public string BillingAadharNo { get; set; }
    public string BillingGSTINNo { get; set; }
    public Nullable<bool> IsActive { get; set; }
    public Nullable<bool> IsDeleted { get; set; }
    public string CreatedBy { get; set; }
    public Nullable<System.DateTime> CreatedOn { get; set; }
    public string UpdatedBy { get; set; }
    public Nullable<System.DateTime> UpdatedOn { get; set; }
    public string GUID { get; set; }
    public string RetailerShopName { get; set; }
    public string BillingProprietorName { get; set; }
}

public partial class tbl_CustomerShippingAddress
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public string ShippingAddress1 { get; set; }
    public string ShippingAddress2 { get; set; }
    public string ShippingCity { get; set; }
    public Nullable<int> FK_StateID { get; set; }
    public string Shippingpin { get; set; }
    public string ShippingEmail { get; set; }
    public string ShippingPhone { get; set; }
    public string ShippingPANNo { get; set; }
    public string ShippingAadharNo { get; set; }
    public string ShippingGSTINNo { get; set; }
    public Nullable<bool> IsActive { get; set; }
    public Nullable<bool> IsDeleted { get; set; }
    public string CreatedBy { get; set; }
    public Nullable<System.DateTime> CreatedOn { get; set; }
    public string UpdatedBy { get; set; }
    public Nullable<System.DateTime> UpdatedOn { get; set; }
    public string GUID { get; set; }
    public string ShippingRetailerShopName { get; set; }
    public string ShippingProprietorName { get; set; }
}

public partial class tbl_ProductMaster
{
    public int Id { get; set; }
    public Nullable<int> FK_CompanyMasterID { get; set; }
    public string ProductName { get; set; }
    public string HSNCode { get; set; }
    public string UOM { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public string CreatedBy { get; set; }
    public Nullable<System.DateTime> CreatedOn { get; set; }
    public string UpdatedBy { get; set; }
    public Nullable<System.DateTime> UpdatedOn { get; set; }
}

public partial class tbl_ProductPrice
{
    public int Id { get; set; }
    public Nullable<int> FK_ProductMasterID { get; set; }
    public decimal Price { get; set; }
    public decimal SGSTPercentageRate { get; set; }
    public decimal CGSTPercentageRate { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public string CreatedBy { get; set; }
    public Nullable<System.DateTime> CreatedOn { get; set; }
    public string UpdatedBy { get; set; }
    public Nullable<System.DateTime> UpdatedOn { get; set; }
}

public partial class tbl_ProductPriceChangesLog
{
    public int id { get; set; }
    public Nullable<System.DateTime> PriceChangeDate { get; set; }
    public Nullable<bool> HasPriceChanged { get; set; }
    public string CreatedBy { get; set; }
    public Nullable<System.DateTime> CreatedOn { get; set; }
    public string ModifiedBy { get; set; }
    public Nullable<System.DateTime> ModifiedOn { get; set; }
}

public partial class tbl_SKSDetails
{
    public int Id { get; set; }
    public string ShopName { get; set; }
    public string ShopProperiterName { get; set; }
    public string ShopAddressLine1 { get; set; }
    public string ShopAddressLine2 { get; set; }
    public string ShopCity { get; set; }
    public string ShopState { get; set; }
    public string ShopPin { get; set; }
    public string ShopPhoneNo { get; set; }
    public string ShopEmail { get; set; }
    public string MobileNo { get; set; }
    public string ShopWebsite { get; set; }
    public string ShopGSTINNo { get; set; }
    public byte[] ShopPropriterSignature { get; set; }
    public string ContactPersonName { get; set; }
    public Nullable<bool> IsActive { get; set; }
    public Nullable<bool> IsDeleted { get; set; }
    public string CreatedBy { get; set; }
    public Nullable<System.DateTime> CreatedOn { get; set; }
    public string UpdatedBy { get; set; }
    public Nullable<System.DateTime> UpdatedOn { get; set; }
    public string ShopPAN { get; set; }
}

public partial class tbl_StateMaster
{
    public int Id { get; set; }
    public string StateName { get; set; }
    public Nullable<bool> IsActive { get; set; }
    public Nullable<bool> IsDeleted { get; set; }
    public string CreatedBy { get; set; }
    public Nullable<System.DateTime> CreatedOn { get; set; }
    public string UpdatedBy { get; set; }
    public Nullable<System.DateTime> UpdatedOn { get; set; }
    public string StateCode { get; set; }
}

public partial class tbl_TransportationMaster
{
    public int Id { get; set; }
    public string TransportationName { get; set; }
    public Nullable<bool> IsActive { get; set; }
    public Nullable<bool> IsDeleted { get; set; }
    public string CreatedBy { get; set; }
    public Nullable<System.DateTime> CreatedOn { get; set; }
    public string UpdatedBy { get; set; }
    public Nullable<System.DateTime> UpdatedOn { get; set; }
}

public partial class tbl_Users
{
    public int id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public Nullable<int> UserRole { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public string GUID { get; set; }
    public string CreatedBy { get; set; }
    public Nullable<System.DateTime> CreatedOn { get; set; }
    public string UpdatedBy { get; set; }
    public Nullable<System.DateTime> UpdatedOn { get; set; }
}

public partial class vw_Bill_InvoiceDetails
{
    public long InvoiceNo { get; set; }
    public int CompanyID { get; set; }
    public string CompanyName { get; set; }
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public string HSNNo { get; set; }
    public int Qnty { get; set; }
    public decimal Rate { get; set; }
    public string UOM { get; set; }
    public decimal Total { get; set; }
    public decimal Discount { get; set; }
    public decimal TaxableValue { get; set; }
    public decimal SGSTRate { get; set; }
    public decimal SGSTValue { get; set; }
    public decimal CGSTRate { get; set; }
    public decimal CGSTValue { get; set; }
}

public partial class vw_BillingCustomer
{
    public int BillingID { get; set; }
    public string BillingCustomer { get; set; }
}

public partial class vw_BillInvoiceMaster
{
    public long InvoiceID { get; set; }
    public string FinancialYear { get; set; }
    public System.DateTime InvoiceDate { get; set; }
    public int FK_BillingCustomerID { get; set; }
    public int FK_ShippingCustomerID { get; set; }
    public decimal InvoiceTotalAmount { get; set; }
    public decimal TotalDiscountonInvoice { get; set; }
    public decimal TotalCollectedAmount { get; set; }
    public Nullable<decimal> FreightCharges { get; set; }
    public Nullable<decimal> LoadingnPackingCharges { get; set; }
    public Nullable<decimal> InsuranceCharges { get; set; }
    public Nullable<decimal> OtherCharges { get; set; }
    public string TransportationMode { get; set; }
    public string VehivleNumber { get; set; }
    public Nullable<System.DateTime> DateNSupplyofTime { get; set; }
    public string PlaceofSupply { get; set; }
    public string RetailerShopName { get; set; }
    public string CustomerName { get; set; }
    public string BillingAddress1 { get; set; }
    public string BillingAddress2 { get; set; }
    public string BillingCity { get; set; }
    public Nullable<int> BillingStateID { get; set; }
    public string BillingStateName { get; set; }
    public string Billingpin { get; set; }
    public string BillingEmail { get; set; }
    public string BillingPhone { get; set; }
    public string BillingPANNo { get; set; }
    public string BillingAadharNo { get; set; }
    public string BillingGSTINNo { get; set; }
    public string ShippingRetailerShopName { get; set; }
    public string ShippingCustomerName { get; set; }
    public string ShippingAddress1 { get; set; }
    public string ShippingAddress2 { get; set; }
    public string ShippingCity { get; set; }
    public Nullable<int> ShippingStateID { get; set; }
    public string ShippingStateName { get; set; }
    public string Shippingpin { get; set; }
    public string ShippingEmail { get; set; }
    public string ShippingPhone { get; set; }
    public string ShippingPANNo { get; set; }
    public string ShippingAadharNo { get; set; }
    public string ShippingGSTINNo { get; set; }
    public string BillingStateCode { get; set; }
    public string ShippingStateCode { get; set; }
    public Nullable<decimal> TotalTaxableAmount { get; set; }
    public Nullable<decimal> TotalSGSTAmount { get; set; }
    public Nullable<decimal> TotalCGSTAmount { get; set; }
    public Nullable<int> TotalProductQuantity { get; set; }
}

public partial class vw_CompanyMaster
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public partial class vw_ProductMaster
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public Nullable<int> FK_CompanyMasterID { get; set; }
    public string HSNCode { get; set; }
    public string UOM { get; set; }
    public string CompanyName { get; set; }
    public bool IsActive { get; set; }
}

public partial class vw_ProductPrice
{
    public int Id { get; set; }
    public Nullable<int> FK_ProductMasterID { get; set; }
    public decimal Price { get; set; }
    public decimal SGSTPercentageRate { get; set; }
    public decimal CGSTPercentageRate { get; set; }
    public string ProductName { get; set; }
    public Nullable<int> FK_CompanyMasterID { get; set; }
    public string HSNCode { get; set; }
    public string UOM { get; set; }
    public string CompanyName { get; set; }
    public bool IsActive { get; set; }
}

public partial class vw_ShippingCustomer
{
    public string ShippingCustomer { get; set; }
    public int ShippingID { get; set; }
}

public partial class getInvoiceDetail_Result
{
    public int Id { get; set; }
    public string ShopName { get; set; }
    public string ShopProperiterName { get; set; }
    public string ShopAddressLine1 { get; set; }
    public string ShopAddressLine2 { get; set; }
    public string ShopCity { get; set; }
    public string ShopState { get; set; }
    public string ShopPin { get; set; }
    public string ShopPhoneNo { get; set; }
    public string ShopEmail { get; set; }
    public string MobileNo { get; set; }
    public string ShopWebsite { get; set; }
    public string ShopGSTINNo { get; set; }
    public byte[] ShopPropriterSignature { get; set; }
    public string ContactPersonName { get; set; }
    public Nullable<bool> IsActive { get; set; }
    public Nullable<bool> IsDeleted { get; set; }
    public string CreatedBy { get; set; }
    public Nullable<System.DateTime> CreatedOn { get; set; }
    public string UpdatedBy { get; set; }
    public Nullable<System.DateTime> UpdatedOn { get; set; }
}