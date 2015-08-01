var aa=function(){
    var from =[], to =[], finalTo =[], finalFrom =[];
    var ff,tt;
    ff=["08:00 AM","10:20 AM","10:40 AM","03:00 PM","03:30 PM"];
    tt=["10:00 AM","10:40 AM","01:00 PM","04:00 PM","05:00 PM"];
    //noprotect
    for(var i=0; i<5;i++){
        var hh,mm,ttt;
       // var fromTime = prompt('Please enter begin time of slot-' + (i+1) +'(hh:mm AM):');
        var fromTime =ff[i];
        hh = parseInt(fromTime.substring(0,2));
        mm = parseInt(fromTime.substring(3,5));
        ttt = fromTime.substring(6,8);
        from.push({
            time : {
                hour : hh,
                minute : mm,
                tt : ttt
            }
        });
        
        //to time input
        
       // var toTime = prompt('Please enter end time of slot-' + (i+1) +'(hh:mm AM):');
        var toTime =tt[i];
        hh = parseInt(toTime.substring(0,2));
        mm = parseInt(toTime.substring(3,5));
        ttt = toTime.substring(6,8);
        to.push({
            time : {
                hour : hh,
                minute : mm,
                tt : ttt
            }
        });        
    }
    finalTo= to.slice(0, 1);
    finalFrom= from.slice(0, 1);
  for(var i=0;i<5;i++){
       console.log(from[i].time.hour);     
   }
   var count=1;
   console.log(finalFrom[0].time.hour);
    for( var i=1; i<=3; i++){
        if((from[i].time.hour <= from[i+1].time.hour) && (from[i].time.tt == from[i+1].time.tt)){
            finalFrom[count] = from[i];
            console.log('inside from if'+finalFrom[count].time.hour);
        }        
        else{
            finalFrom[count] = from[i+1];
             console.log('inside from else'+finalFrom[count].time.hour);
        }
        if((to[i].time.hour == from[i+1].time.hour)){
            finalTo[count] = to[i+1];
            i++;
        }
        else if((to[i].time.hour <= to[i+1].time.hour) && (to[i].time.tt == to[i+1].time.tt) ){
            finalTo[count] = to[i+1];
            console.log('inside to if'+finalTo[count].time.hour);
        }
        else{
            finalTo[count] = to[i];
             console.log('inside to else'+finalTo[count].time.hour);
        }
        count++;
    }
    for(var i=0; i<=2; i++){
        console.log('From->'+finalFrom[i].time.hour+':'+finalFrom[i].time.minute+' '+finalFrom[i].time.tt+' To-> '+finalTo[i].time.hour+':'+finalTo[i].time.minute+' '+finalTo[i].time.tt)
    }
   
       
};
aa();