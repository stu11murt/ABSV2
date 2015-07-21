$(document).ready(function () {

    $('#paymentSuccess').hide();
    $('#paymentError').hide();

    $('#booking_StartTime').timepicker({
        'scrollDefault': '9:00am',
        'minTime': '9:00am',
        'maxTime': '6:30pm',
        'showDuration': false
    });
    
  
    $(".time").each(function () {
       $(this).timepicker({
            'scrollDefault': '9:00am',
            'minTime': '9:00am',
            'maxTime': '6:30pm',
            'showDuration': false
        });
    });

    var $subPay = $('#submitPayment');
    var $subClose = $('#onlineClose')
    var $paymentSucc = $('#paymentSuccess');
    var $paymentErr = $('#paymentError');

    $subPay.click(function () {
        var NoC = $('#OnlinePay_NameOnCard').val();
        var CCNum = $('#OnlinePay_CreditCardNumber').val();
        var VFrom = $('#OnlinePay_ValidFrom').val();
        var ExDate = $('#OnlinePay_ExpiryDate').val();
        var CCv = $('#OnlinePay_CCV2').val();
        var PayEmail = $('#OnlinePay_PayeeEmail').val();
        alert(NoC);
           
        $.post("/BookingForm/SubmitOnlinePayment/", { NameOnCard: NoC, CCNumber: CCNum, ValidFrom: VFrom, ExpiryDate: ExDate, CCVNumber: CCv, PayeeEmail: PayEmail }, function(data) {
            if(data == "Passed")
            {
                $paymentErr.hide();
                $paymentSucc.show();
                $subPay.hide();
                $subClose.hide();
            }
            else
            {
                $paymentErr.show();
                $paymentSucc.hide();
            }

        });
    });
    var $eventCh = $('#eventCheck');

    $eventCh.click(function () {
        alert($eventCh.prop('checked'));
    });
      
});

