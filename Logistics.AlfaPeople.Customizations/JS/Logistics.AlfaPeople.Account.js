if (typeof (Logistics) == "undefined") { Logistics = {} }
if (typeof (Logistics.Account) == "undefined") { Logistics.Account = {} }


Logistics.Account = {

    OnChange: function (executionContext) {

        var formContext = executionContext.getFormContext();
        var nameAccount = formContext.getAttribute("name").getValue();

        nameAccount = nameAccount.toLowerCase().replace(/(?:^|\s)\S/g, function (w) {
            return w.toUpperCase();
        });

        formContext.getAttribute("name").setValue(nameAccount);
    }
}