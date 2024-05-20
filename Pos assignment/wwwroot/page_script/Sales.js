function salesVM() {
    var self = this;
    self.product = ko.observable();
    self.quantity = ko.observable();

    self.customer = ko.observable();
    self.paymentmethod = ko.observable();
    self.totalamount = ko.observable();
    self.userAmount = ko.observable();

    //workinglist
    self.productlist = ko.observableArray([]);
    self.customerList = ko.observableArray([]);
    self.paymentmethodList = ko.observableArray([]);

    postRequest('/Sales/GetAllProduct', null, self.productlist);
    postRequest('/Sales/GetAllCustomer', null, self.customerList);
    postRequest('/Sales/GetAllPaymentMethod', null, self.paymentmethodList);

    console.log(self.paymentmethodList())

    self.addedProductList = ko.observableArray([]);


    self.customerName = ko.observable();
    self.paymentmethodName = ko.observable();
    self.GroceryName = ko.observable('Maskey Grocery');



    self.entryDate = ko.observable(new Date().toDateString());


    self.AddValidation = function () {
        var errormessage = "";
        if (self.product() == undefined) {
            ShowToastMessage('error', 'Please Select Product');
            errormessage += '1';
        }

        if (self.quantity() == undefined) {
            ShowToastMessage('error', 'Please Select quantity');
            errormessage += '1';
        }

        if (errormessage == "") {
            return true;
        }
        else {
            return false;
        }
    }


    self.addProduct = function () {
        if (self.AddValidation()) {
            var prod_name = self.productlist().filter(x => x.id == self.product())[0].productname;
            var prod_price = self.productlist().filter(x => x.id == self.product())[0].price;
            var rowdata = {};
            rowdata.product_id = self.product();
            rowdata.productName = prod_name;
            rowdata.productPrice = prod_price;
            rowdata.total_prod_amount = self.quantity() * prod_price;
            rowdata.quantity = self.quantity();
            self.addedProductList.push(rowdata);

            self.product(null);
            self.quantity(null);
        }
    }

    self.removeProduct = function (data) {
        self.addedProductList.remove(data);
    }


    self.savevalidation = function () {
        var errormessage = "";
        if (self.customer() == undefined) {
            ShowToastMessage('error', 'Please Select customer');
            errormessage += '1';
        }

        if (self.paymentmethod() == undefined) {
            ShowToastMessage('error', 'Please Select paymentmethod');
            errormessage += '1';
        }

        if (self.userAmount() == undefined) {
            ShowToastMessage('error', 'Please Select Paid Amount');
            errormessage += '1';
        }

        if (self.addedProductList().length < 1) {
            ShowToastMessage('error', 'Please Select at least one product');
            errormessage += '1';
        }

        if (errormessage == "") {
            return true;
        }
        else {
            return false;
        }
    }


    self.save = function () {
        $('#modal-container').modal('show');

        
        if (self.savevalidation()) {
            console.log(self.addedProductList(), self.customer(), self.paymentmethod(), self.userAmount(), 'amount');


            var customerName = self.customerList().filter(x => x.id == self.customer())[0].customerName;
            var paymemtMethod = self.paymentmethodList().filter(x => x.id == self.paymentmethod())[0].name;


            self.customerName(customerName);
            self.paymentmethodName(paymemtMethod);

            var finalData = {
                customer_Id: self.customer(),
                payment_method_id: self.paymentmethod(),
                paid_amount: self.userAmount(),
                SalesProduct: self.addedProductList()
            }

            //postRequest('/Sales/SaveSales', finalData, res => {
            //    console.log(res, 'res');
            //})
        }
    }

    self.closeModal = function () {
        $('#modal-container').modal('hide');
    }

    self.print = function () {
        var divContents = document.getElementById("div-to-print").innerHTML;
        var a = window.open('', '', 'height=500, width=500');
        a.document.write(divContents);
        a.document.close();
        a.print(); 
    }


}
$(document).ready(function () {
    ko.applyBindings(new salesVM());
})
