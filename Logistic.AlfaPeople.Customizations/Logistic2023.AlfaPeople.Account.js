if (typeof (Logistic) == "undefined") { Logistic = {} }
if (typeof (Logistic.Account) == "undefined") { Logistic.Account = {} }


Logistic.Account = {

    OnChange: function (executionContext) {
       
        var formContext = executionContext.getFormContext();
        var nameAccount = formContext.getAttribute("name").getValue();

        nameAccount = nameAccount.toLowerCase().replace(/(?:^|\s)\S/g, function (w) {
            return w.toUpperCase();
        });

        formContext.getAttribute("name").setValue(nameAccount);
    }
}