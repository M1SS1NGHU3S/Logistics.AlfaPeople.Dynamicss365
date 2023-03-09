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
    },
    OnCepChange: function (executionContext) {
        var formContext = executionContext.getFormContext();
        var id = Xrm.Page.data.entity.getId();

        var contaCep = formContext.getAttribute("address1_postalcode").getValue();

		var execute_grp_GetEndereoViaCEP_Request = {
			// Parameters
			entity: { entityType: "account", id: id }, // entity
			CEP: contaCep, // Edm.String

			getMetadata: function () {
				return {
					boundParameter: "entity",
					parameterTypes: {
						entity: { typeName: "mscrm.account", structuralProperty: 5 },
						CEP: { typeName: "Edm.String", structuralProperty: 1 }
					},
					operationType: 0, operationName: "grp_GetEndereoViaCEP"
				};
			}
		};

		Xrm.WebApi.execute(execute_grp_GetEndereoViaCEP_Request).then(
			function success(response) {
				debugger;
				if (response.ok) { return response.json(); }
			}
		).then(function (responseBody) {
			debugger;
			var result = responseBody;
			console.log(result);
			// Return Type: mscrm.grp_GetEndereoViaCEPResponse
			// Output Parameters
			var logradouro = result["Logradouro"]; // Edm.String
			var complemento = result["Complemento"]; // Edm.String
			var bairro = result["Bairro"]; // Edm.String
			var localidade = result["Localidade"]; // Edm.String
			var uf = result["UF"]; // Edm.String
			var ibge = result["IBGE"]; // Edm.String
			var ddd = result["DDD"]; // Edm.String

			formContext.getAttribute("grp_logradouro").setValue(logradouro);
			formContext.getAttribute("grp_complemento").setValue(complemento);
			formContext.getAttribute("grp_bairro").setValue(bairro);
			formContext.getAttribute("grp_localidade").setValue(localidade);
			formContext.getAttribute("grp_uf").setValue(uf);
			formContext.getAttribute("grp_ibge").setValue(ibge);
			formContext.getAttribute("grp_ddd").setValue(ddd);
		}).catch(function (error) {
			debugger;
			console.log(error.message);
		});
    }
}