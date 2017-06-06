
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

  async.each([1], function (itemNumber, callback) {
    describe('Test Case ' + itemNumber, function () {
      it("should be a number", function (done) {
        
        $.ajax({
          type: "GET", //GET or POST or PUT or DELETE verb
          url: 'https://dotnetcore-govinda777.c9users.io/api/Values/Get', // Location of the service
          crossDomain: true,
          success: function (msg) {//On Successfull service call
           
            assert.equal(itemNumber,itemNumber);
            done();
          },
          error: function (msg) {// When Service call fails
            debugger;
            alert('erro');
          }
        });
      });
    });
    callback()
  });

});
