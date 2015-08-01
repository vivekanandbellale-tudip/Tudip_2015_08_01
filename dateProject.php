<html>
<head>
 <title><h2>Test</h2></title>
</head>
<body>
<label>Enter number of time slot </label>
<input type="text" value="0" id="no">
<br><br>
  <input type="time" id="startdate" value="11:00" name="startdate"> to <input type="time" value="12:00" id="enddate" name="enddate">
<button onclick="timeSlot()" >Add time slot</button>
<button onclick="showSlots()">Show Ans.</button>
<br><br>
 
<input type="text" value="" id="starttime" readonly> to <input type="text" value="" id="endtime" readonly>
</body>
</html>

    <script type="javascript">
    timeArray = [];
    numberOfSlote = 0;
    function timeSlot() {

        var enddate = $("#enddate").val();
        var startdate = $("#startdate").val();
        var arr = [startdate,enddate];
        document.getElementById('starttime').value = startdate;
        document.getElementById('endtime').value = enddate;
         numberOfSlote++;
            timeArray.push(arr);

    }
    function showSlots() {
        var n = 0,m=1;
        sdate = [];edate = [];
        for(var i =0 ; i<numberOfSlote;i++ ){
            var sTime = timeArray[i][0];
            var oDate = new Date();
            oDate.setUTCHours(
                parseInt(sTime.substr(0, 2), 10),
                parseInt(sTime.substr(3, 2), 10),
                0,
                0
            );
            var eTime = timeArray[i][0];
            var oDate1 = new Date();
            oDate1.setUTCHours(
                parseInt(eTime.substr(0, 2), 10),
                parseInt(eTime.substr(3, 2), 10),
                0,
                0
            );

            sdate[i] = oDate.getTime();
            edate[i] = oDate1.getTime();
        }
        alert(edate);
    }
</script>