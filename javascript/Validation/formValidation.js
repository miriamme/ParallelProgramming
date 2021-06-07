'use strict'

let formValidation = (function(){
    let validation = {
        formId : null,
        attributeName : null,
        inputInfo : {
            inputTexts : [],
            checkboxs : [],
            selects : [],
            textareas : []
        },
        result : {passedElements:[], failedElements:[], messages:[], isPassed:true},
        init : function(formId, attributeName) {
            this.formId = formId;
            this.attributeName = attributeName || configuration.findAttribute;
        },
        verify: function(){
            this.clearItem();            

            this.collect();

            if (!this.hasItem())
                return this.result;

            this.check();

            return this.result;
        },
        check : function(){
            //console.log(this.inputInfo);
            for(const property in this.inputInfo){
                if (this.inputInfo[property].length > 0) {
                    const ele = this.inputInfo[property];
                    for(let i=0; i<ele.length; i++){
                        const checkTypes = ele[i].checkTypeCodes;
                        this.checkItem(document.querySelector(`#${ele[i].id}`), ele[i].val, checkTypes);
                    }
                }
            }
        },
        collect : function(){
            let $this = this;
            const form = document.getElementById(this.formId);
            if (form){
                const list = document.querySelectorAll("form input, form select, form textarea");
                list.forEach(element => {
                    const verify = element.getAttribute($this.attributeName);
                    if (verify){
                        const verifies = verify.split('|');
                        switch (element.tagName) {
                            case "INPUT":
                                const type = element.getAttribute("type");
                                switch (type.toUpperCase()){
                                    case "TEXT":
                                        $this.addItem(configuration.elementTypeCode.Text, element.id, element.value, verifies);
                                        break;
                                    case "CHECKBOX":
                                        $this.addItem(configuration.elementTypeCode.CheckBox, element.id, element.checked, verifies);
                                        break;
                                }
                                break;
                            case "SELECT":
                                $this.addItem(configuration.elementTypeCode.Select, element.id, element.options[element.selectedIndex].value, verifies);
                                break;
                            case "TEXTAREA":
                                $this.addItem(configuration.elementTypeCode.Textarea, element.id, element.value, verifies);
                                break;
                        }
                    }

                });
            }
        },
        hasItem : function(){
            let count = 0;
            for (const property in this.inputInfo)
                count += this.inputInfo[property].length;
            return count > 0;
        },
        addItem : function(elementTypeCode, id, value, checkTypeCodes){
            switch(elementTypeCode){
                case configuration.elementTypeCode.Text:
                    this.inputInfo.inputTexts.push({id:id, val:value, checkTypeCodes:checkTypeCodes});
                    break;
                case configuration.elementTypeCode.CheckBox:
                    this.inputInfo.checkboxs.push({id:id, val:value, checkTypeCodes:checkTypeCodes});
                    break;
                case configuration.elementTypeCode.Select:
                    this.inputInfo.selects.push({id:id, val:value, checkTypeCodes:checkTypeCodes});
                    break;
                case configuration.elementTypeCode.Textarea:
                    this.inputInfo.textareas.push({id:id, val:value, checkTypeCodes:checkTypeCodes});
                    break;
            }
        },
        clearItem : function(){
            this.result = {passedElements:[], failedElements:[], messages:[], isPassed:true};
            for (const property in this.inputInfo)
                this.inputInfo[property] = [];
        },
        checkItem: function(element, value, checkTypes){
            for(let i=0; i<checkTypes.length; i++){
                let checkType = checkTypes[i];
                let option = "";
                if (checkTypes[i].indexOf(':') > 0){
                    const temp = checkTypes[i].split(':');
                    checkType = temp[0];
                    option = temp[1];
                }

                if (!configuration.checkType[checkType].check(value, option)){
                    this.result.failedElements.push(element);
                    this.result.messages.push(configuration.checkType[checkType].message);
                    this.result.isPassed = false;
                }
                else{
                    this.result.passedElements.push(element);
                }
            }
        }
    }

    const configuration = {
        findAttribute : "verify",
        elementTypeCode : {
            Text : 0,
            CheckBox : 1,
            Select : 2,
            Textarea : 3
        },
        checkType : {
            noempty : {
                message : {"en":"no empty", "kr":"빈값허용안함"}, 
                check: function(value){
                    if (typeof value === "string" && value === "")
                        return false;
                    return true;
                }
            },
            number : {
                message : {"en":"only number", "kr":"숫자만 허용"},
                check : function(value){
                    const parsed = parseInt(value, 10);
                    if (isNaN(parsed)) return false;
                    return true;
                }
            },
            nozeroindex : {
                message: {"en":"select something", "kr":"선택하세요"},
                check:function(value){
                    return parseInt(value) > 0;
                }
            },
            check : {
                message: {"en":"no check", "kr":"참거짓 체크 불일치"},
                check:function(value, trueOrFalse){
                    return value.toString() === trueOrFalse;
                }
            },
            min : {
                message: {"en":"no minimum length", "kr":"최소길이 불일치"},
                check:function(value, length){
                    return value.length >= length;
                }
            },
            max : {
                message: {"en":"no maximum length", "kr":"최대길이 불일치"},
                check:function(value, length){
                    return value.length <= length;
                }
            },
            regex : {
                message: {"en":"no matching", "kr":"입력값이 유효하지 않음"},
                check:function(value, expression){
                    let re = new RegExp(expression, "g");
                    return re.test(value);
                }
            }
        }
    }

    return {
        load: function(formId, attributeName){
            validation.init(formId, attributeName);
        },
        verify: function(callback){
            let result = validation.verify();
            callback(result);
        }
    }

})();