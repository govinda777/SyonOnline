
'use strict';

var assert = chai.assert;
var async = async;
var soap = $.soap;

var xmlString = ['<soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:tem="http://tempuri.org/" xmlns:red="http://schemas.datacontract.org/2004/07/Redecard.Komerci.External.WcfKomerci">',
    '<soapenv:Header/>',
    '<soapenv:Body>',
    '<tem:GetAuthorizedCredit>',
    '<tem:request>',
    '</tem:request>',
    '</tem:GetAuthorizedCredit>',
    '</soapenv:Body>',
    '</soapenv:Envelope>'];

describe('Validação ADQ v1', function () {

    var resultTest = [{}, {}];
    
    $.ajax({
        type: "GET", //GET or POST or PUT or DELETE verb
        async: false,
        url: 'http://localhost:50530/api/adquirencia/validateall', // Location of the service
        crossDomain: true,
        success: function (data) {//On Successfull service call
            resultTest = data;
        },
        error: function (msg) {// When Service call fails
            debugger;
            alert('erro');
        }
    });
    
    async.each(resultTest, function (item) {
        
        describe('Test Case ' + item.isPass , function () {
            
            it("isPass :" + item.isPass, function (done) {

                assert.equal(item.isPass, true);
                done();
            });

            it("message :" + item.message, function (done) {

                assert.equal(item.message, "");
                done();
            });

            it("totalTime :" + item.totalTime, function (done) {
                var timeout = item.totalTime > 4;

                assert.isOk(!timeout, timeout ? "TEMPO MAIOR DO QUE O ESPERADO" : "Dentro do esperado");
                done();
            });
        });
        
    });



});
