<input type="time" id="startdate" value="11:00" name="startdate"> to <input type="time" value="12:00" id="enddate" name="enddate">
<button onclick="myFunction()" >Add time slot</button>
<button onclick="myFunction1()">Show Ans.</button>
<br><br>
<input type="text" value="" id="starttime" readonly> to <input type="text" value="" id="endtime" readonly>
<div class="timespan">

    </div>

    <script>
    timeArray = [];
    numberOfSlote = 0;
    function myFunction() {
        var enddate = $("#enddate").val();
        var startdate = $("#startdate").val();
        var arr = [startdate, enddate];
        document.getElementById('starttime').value = startdate;
        document.getElementById('endtime').value = enddate;
        numberOfSlote++;
        timeArray.push(arr);
    }

    function myFunction1() {
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
        var finalsdate = [];
        var finaledate = [];
        flage = 0;

        for(var a = 0 ;a < edate.length;a++)
        {
                if(edate[a] >= sdate[a+1]){
                     finalsdate.push(sdate[a]);
                     finaledate.push(edate[a+1]);
                flage = 1;
                }else if(flage == 1){
            flage = 0;
        }else{
                    finalsdate.push(sdate[a]);
                    finaledate.push(edate[a]);
                }
        }
         for(i=0;i<finalsdate.length;i++){
            var html = "";
              var date = new Date(finalsdate[i]* 1000);
             var sh    = date.getHours();
             var sm   = date.getMinutes();
             var date1 = new Date(finaledate[i]* 1000);
             var eh    = date1.getHours();
             var em   = date1.getMinutes();
             html ='start time:<input type="text" value="'+sh+':'+sm+'" name="startTime'+i+'"> endtime: <input type="text" value="'+eh+':'+em+'" name="endTime'+i+'"><br><br>';
            $('.timespan').append(html);
        }
    }
</script>
