
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

	var getRandomText = function a() {
		var h = ["Товарищи,", "С другой стороны", "Равным образом", "Не следует, однако, забывать, что", "Таким образом,", "Повседневная практика показывает, что", "Значимость этих проблем настолько очевидна, что", "Разнообразный и богатый опыт", "Задача организации, в особенности же", "Идейные соображения высшего порядка, а также"];
		var f = ["реализация намеченных плановых заданий", "рамки и место обучения кадров", "постоянный количественный рост и сфера нашей активности", "сложившаяся структура организации", "новая модель организационной деятельности", "дальнейшее развитие различных форм деятельности", "постоянное информационно-пропагандистское обеспечение нашей деятельности", "укрепления и развития структуры", "консультация с широким активом", "начало повседневной работы по формированию позиции"];
		var e = ["играет важную роль в формировании", "требуют определения и уточнения", "способствует подготовке и реализации", "обеспечивает широкому кругу (специалистов) участие в формировании", "позволяет выполнить важные задания по разработке", "в значительной степени обусловливает создание", "позволяет оценить, значение", "представляет собой интересный эксперимент проверки", "влечет за собой процесс внедрения и модернизации"];
		var d = ["существенных финансовых и административных условий", "дальнейших направлений развития", "системы массового участия", "позиций, занимаемых участниками в отношении поставленных задач", "новых предложений", "направлений прогрессивного развития", "системы обучения кадров, соответствующей насущным потребностям", "соответствующих условий активизации", "модели развития", "форм воздействия"];
		var k = Math.floor(Math.random() * h.length);
		var j = Math.floor(Math.random() * f.length);
		var i = Math.floor(Math.random() * e.length);
		var g = Math.floor(Math.random() * d.length);
		var c = h[k] + " " + f[j] + " " + e[i] + " " + d[g] + "!";
		return c
	};
	var getRandomAvatarPath = function a(){
		var random = Math.floor(Math.random() * (16)) + 1;
		var c = "avatars/users-"+random+".svg";
		return c
    };

    for(let i = 1; i<200; i++)
	{
        var divider = document.createElement("DIV");
        divider.setAttribute("class","section_divider");
        document.getElementById("wall").appendChild(divider);
        
        var row = document.createElement("div");
        row.setAttribute("class","section_row");
        row.setAttribute("id","row"+i);
        document.getElementById("wall").appendChild(row);

        var left = document.createElement("DIV");
        left.innerHTML = names[Math.floor(Math.random() * (19)) + 1];
        left.setAttribute("id","left"+i);
        left.setAttribute("class","section_left");
        document.getElementById("row"+i).appendChild(left);

        var ava = document.createElement("img");
        ava.src = getRandomAvatarPath();
        ava.style.width = "100%";
        ava.style.borderRadius = "100%";
        document.getElementById("left"+i).appendChild(ava);

        var comment = document.createElement("div");
        comment.setAttribute("class","section_comment");
        comment.setAttribute("id","comment"+i);
        comment.innerHTML = getRandomText();
        document.getElementById("row"+i).appendChild(comment);

        var clear = document.createElement("div");
        clear.style.clear = "both";
        document.getElementById("row"+i).appendChild(clear);

    }
}
    window.onload = init;
