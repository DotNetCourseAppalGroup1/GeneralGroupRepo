function init() {

    var names = ["Шамякин Иосиф",
        "Трындин Ростислав",
        "Круглов Георгий",
        "Белолипецкий Семен",
        "Ястремский Евгений",
        "Кутяков Сократ",
        "Яндиев Мечислав",
        "Семенов Захар",
        "Набадчиков Кирилл",
        "Шинский Прокофий",
        "Табаков Илья",
        "Хигир Лавр",
        "Ювелев Ульян",
        "Саянович Эммануил",
        "Михеев Алексей",
        "Арсеиньев Никанор",
        "Наумов Максим",
        "Ситников Арсений",
        "Яговенко Дементий",
        "Хабалов Аркадий"];

        var getRandomAvatarPath = function a(){
            var random = Math.floor(Math.random() * (16)) + 1;
            var c = "avatars/users-"+random+".svg";
            return c
        };
    
	for(let i = 1; i<200; i++)
	{
        var x = document.createElement("A");
        x.setAttribute("id","friend"+i);
        x.href = "";
        x.setAttribute("class","friendLink_collor");
        document.getElementById("friend_list").appendChild(x);
        
        var y = document.createElement("LI");
        y.setAttribute("id","friendLi"+i);
        y.setAttribute("class","friend_avatar");
        y.innerHTML = names[Math.floor(Math.random() * (19)) + 1];
        document.getElementById("friend"+i).appendChild(y);

        var z = document.createElement("IMG");
        z.src = getRandomAvatarPath();
        document.getElementById("friendLi"+i).appendChild(z);
	}
}

window.onload = init;
    
  