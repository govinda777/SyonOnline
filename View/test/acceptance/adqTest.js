
'use strict';

var assert = chai.assert;
var async = async;

describe('Validação ADQ', function () {

    var resultTest = [{}, {}];
    
    $.ajax({
        type: "GET", //GET or POST or PUT or DELETE verb
        async: false,
        url: 'http://localhost:8082/api/adquirencia/validateall', // Location of the service
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
        
        describe('Test Case ' + item.order , function () {
            
            it("isPass :" + item.isPass, function (done) {

                assert.equal(item.isPass, true);
                done();
            });

            if (item.message != '')
            {
                it("message :" + item.message, function (done) {

                    assert.equal(item.message, "");
                    done();
                });
            }
            
            it("totalTime :" + item.totalTime, function (done) {
                var timeout = item.totalTime > 4;

                assert.isOk(!timeout, timeout ? "TEMPO MAIOR DO QUE O ESPERADO" : "Dentro do esperado");
                done();
            });
        });
        
    });



});
