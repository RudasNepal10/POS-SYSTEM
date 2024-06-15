function salesVM() {
    var self = this;
    self.product = ko.observable();
    self.quantity = ko.observable();

    self.customer = ko.observable();
    self.paymentmethod = ko.observable();
    self.userAmount = ko.observable(0);

    //workinglist
    self.productlist = ko.observableArray([]);
    self.customerList = ko.observableArray([]);
    self.paymentmethodList = ko.observableArray([]);

    postRequest('/Sales/GetAllProduct', null, self.productlist);
    postRequest('/Sales/GetAllCustomer', null, self.customerList);
    postRequest('/Sales/GetAllPaymentMethod', null, self.paymentmethodList);


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
        console.log(self.productlist(), self.product())
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

    self.totalamount = ko.computed(function () {
        return self.addedProductList().reduce((acc, product) => acc + product.total_prod_amount, 0);
    }, this);

    self.VAT = ko.computed(function () {
        return parseFloat(13 / 100 * self.totalamount()).toFixed(2);
    }, this);


    self.grandTotal = ko.computed(function () {
        return self.totalamount() +  +self.VAT();
    }, this);

    self.dueAmount = ko.computed(function () {
        var due = parseFloat(self.grandTotal()) - parseFloat(self.userAmount());
        return due > 0 ? due.toFixed(2) : "0.00";
    }, this);

    self.returnAmount = ko.computed(function () {
        var returnAmount = parseFloat(self.userAmount()) - parseFloat(self.grandTotal());
        return returnAmount > 0 ? returnAmount.toFixed(2) : "0.00";
    }, this);

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
        if (self.savevalidation()) {
            var customerName = self.customerList().filter(x => x.id == self.customer())[0].customerName;
            var paymemtMethod = self.paymentmethodList().filter(x => x.id == self.paymentmethod())[0].name;

            self.customerName(customerName);
            self.paymentmethodName(paymemtMethod);

            var finalData = {
                customer_Id: self.customer(),
                payment_method_id: self.paymentmethod(),
                paid_amount: self.userAmount(),
                vat_amount: self.VAT(),
                total_amount: self.totalamount(),
                SalesProduct: self.addedProductList(),
                due_amount: self.dueAmount(),
                return_amount: self.returnAmount()
            }

            $('#modal-container').modal('show');

            postRequest('/Sales/SaveSales', finalData, res => {
                ShowToastMessage('success', 'Order Placed Successfully');
            })
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
