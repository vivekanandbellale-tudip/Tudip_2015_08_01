function timeCal(){
	var time = {
		from: ["8:00 AM", "10:20 AM", "10:40 AM", "3:00 PM"],
		to: ["10:00 AM", "10:40 AM", "1:00 PM", "4:00 PM"]
	};

	var i=0;
	for (i=0;i<time.to.length-1; i++)
	{
		if(time.to[i] === time.from[i+1] || time.from[i]<time.to[i+1])
		{
			time.to[i]= time.to[i+1];
			time.to.splice(i+1, 1);
			time.from.splice(i+1, 1);
		}
	}
	console.log(time);
}