function descricao(obj){
    let txtdescricao = ""
    let objId = obj.id
    if (objId == "nome"){txtdescricao = "Este campo representa o nome completo."}
    if (objId == "email"){txtdescricao = "Este campo representa o e-mail."}
    if (objId == "cpf"){txtdescricao = "Este campo representa o CPF."}
    if (objId == "dtnasc"){txtdescricao = "Este campo representa a data de nascimento."}
    if (objId == "cel"){txtdescricao = "Este campo representa o telefone celular incluindo DDD."}
    if (objId == "fixo"){txtdescricao = "Este campo representa o telefone fixo incluindo DDD."}
    if (objId == "sexo"){txtdescricao = "Este campo representa o sexo."}
    if (objId == "cnpj"){txtdescricao = "Este campo representa o cnpj."}
    if (objId == "rzsocial"){txtdescricao = "Este campo representa a razão social (nome legal)."}
    if (objId == "nmfantasia"){txtdescricao = "Este campo representa nome fantasia da empresa (nome comercial)."}
    if (objId == "senha"){txtdescricao = "Este campo representa a senha ."}
    if (objId == "confsenha"){txtdescricao = "Este campo representa a confirmação de senha que deve ser idêntica a senha ."}
    window.alert(txtdescricao)
    console.log("hi")
}