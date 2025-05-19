let hasKey = false;
let knowsSecret = false;
let hasMap = false;
let metAlly = false;
let trustPoints = 0;
let playerName = "";

const output = document.getElementById('game-output');
const input = document.getElementById('game-input');

function print(text) {
  output.innerHTML += `<p>${text}</p>`;
  output.scrollTop = output.scrollHeight;
}
function clearInput() {
  input.innerHTML = '';
}
function askName() {
  clearInput();
  print("=== ТАЙНА ЗАБРОШЕННОГО ПОМЕСТЬЯ ===");
  print("Введите имя вашего персонажа:");
  input.innerHTML = `<input type="text" id="nameInput"><button onclick="saveName()">OK</button>`;
  document.getElementById('nameInput').focus();
}
function saveName() {
  const val = document.getElementById('nameInput').value.trim();
  if (val) {
    playerName = val;
    clearInput();
    Chapter1();
  }
}
function showChoices(choices) {
  clearInput();
  choices.forEach((choice, i) => {
    const btn = document.createElement('button');
    btn.textContent = choice.text;
    btn.onclick = choice.action;
    input.appendChild(btn);
  });
}

// Главы и сюжет

function Chapter1() {
  print(`<br>=== ГЛАВА 1: ПРОБУЖДЕНИЕ ===`);
  print(`${playerName}, вы просыпаетесь в незнакомой комнате старинного поместья.`);
  showChoices([
    { text: 'Осмотреться вокруг', action: lookAround },
    { text: 'Попробовать открыть дверь', action: tryDoor },
    { text: 'Кричать о помощи', action: callForHelp },
    { text: 'Выйти из игры', action: () => location.reload() }
  ]);
}

function lookAround() {
  print('<br>В комнате вы видите:');
  showChoices([
    { text: 'Старый ключ на столе', action: () => {
      hasKey = true;
      print('Вы взяли ключ. Он выглядит подходящим для двери.');
      Chapter1();
    }},
    { text: 'Записку на подоконнике', action: () => {
      knowsSecret = true;
      print("На записке написано: 'Не доверяйте теням'.");
      Chapter1();
    }},
    { text: 'Странный символ на стене', action: () => {
      print('Символ светится при вашем прикосновении!');
      trustPoints++;
      Chapter1();
    }},
    { text: 'Вернуться', action: Chapter1 }
  ]);
}

function tryDoor() {
  if (hasKey) {
    print('<br>Вы открываете дверь и попадаете в длинный коридор.');
    Chapter2();
  } else {
    print('<br>Дверь заперта. Нужно найти ключ.');
    Chapter1();
  }
}

function callForHelp() {
  print('<br>Ваши крики привлекли внимание...');
  showChoices([
    { text: 'Продолжить звать на помощь', action: () => {
      ShowEnding(1, 'Дверь распахивается, и вас хватают темные силуэты...', false);
    }},
    { text: 'Затаиться', action: () => {
      print('Шаги проходят мимо. Вы в безопасности... пока.');
      Chapter1();
    }}
  ]);
}

function Chapter2() {
  print('<br>=== ГЛАВА 2: КОРИДОР ТАЙН ===');
  print('Перед вами три двери и лестница наверх:');
  showChoices([
    { text: 'Красная дверь (помечена черепом)', action: RedDoor },
    { text: 'Синяя дверь (слышны голоса)', action: BlueDoor },
    { text: 'Зеленая дверь (пахнет травами)', action: GreenDoor },
    { text: 'Подняться по лестнице', action: Stairs }
  ]);
}

function RedDoor() {
  print('<br>За дверью - лаборатория алхимика.');
  showChoices([
    { text: 'Исследовать стол', action: () => {
      if (knowsSecret) {
        ShowEnding(2, 'Вы находите эликсир и используете его, чтобы покинуть поместье!', true);
      } else {
        ShowEnding(3, 'Вы выпиваете неизвестную жидкость и превращаетесь в статую...', false);
      }
    }},
    { text: 'Осмотреть книжную полку', action: () => {
      hasMap = true;
      print('Вы нашли карту поместья!');
      Chapter2();
    }},
    { text: 'Выйти', action: Chapter2 }
  ]);
}

function BlueDoor() {
  print('<br>В комнате сидит старик.');
  showChoices([
    { text: 'Заговорить с ним', action: () => {
      metAlly = true;
      trustPoints += 2;
      print('Старик оказывается бывшим хозяином поместья. Он дает вам совет.');
      Chapter2();
    }},
    { text: 'Атаковать его', action: () => {
      ShowEnding(4, 'Старик оказывается призраком и забирает вашу душу...', false);
    }},
    { text: 'Уйти', action: Chapter2 }
  ]);
}

function GreenDoor() {
  print('<br>Вы в оранжерее с экзотическими растениями.');
  showChoices([
    { text: 'Сорвать красный цветок', action: () => {
      ShowEnding(5, 'Цветок оживает и опутывает вас корнями...', false);
    }},
    { text: 'Сорвать синий цветок', action: () => {
      trustPoints++;
      print('Цветок дает вам странное видение...');
      Chapter2();
    }},
    { text: 'Выйти', action: Chapter2 }
  ]);
}

function Stairs() {
  print('<br>Поднявшись, вы видите:');
  showChoices([
    { text: 'Дверь в чердак', action: Attic },
    { text: 'Окно с возможностью выбраться', action: () => {
      if (trustPoints >= 3) {
        ShowEnding(6, 'Вы выбираетесь через окно и оказываетесь в безопасности!', true);
      } else {
        ShowEnding(7, 'Вы падаете и ломаете ногу... Тени приближаются...', false);
      }
    }},
    { text: 'Вернуться', action: Chapter2 }
  ]);
}

function Attic() {
  print('<br>На чердаке вы находите древний артефакт.');
  showChoices([
    { text: 'Взять его', action: () => {
      if (metAlly && hasMap) {
        ShowEnding(8, 'Артефакт переносит вас домой! Вы спасены!', true);
      } else {
        ShowEnding(9, 'Артефакт поглощает ваше сознание...', false);
      }
    }},
    { text: 'Оставить', action: () => {
      print('Вы чувствуете, что сделали правильный выбор.');
      trustPoints++;
      FinalChoice();
    }}
  ]);
}

function FinalChoice() {
  print('<br>=== ФИНАЛЬНЫЙ ВЫБОР ===');
  showChoices([
    { text: 'Попытаться найти другой выход', action: () => {
      if (trustPoints >= 4) {
        ShowEnding(10, 'Используя все полученные знания, вы находите тайный выход!', true);
      } else {
        print('Вы блуждаете по коридорам...');
        ShowEnding(11, 'Поместье не отпускает вас... Вы становитесь его частью.', false);
      }
    }},
    { text: 'Вернуться к старику за советом', action: () => {
      if (metAlly) {
        ShowEnding(12, 'Старик раскрывает вам последний секрет и помогает сбежать!', true);
      } else {
        ShowEnding(13, 'Старика нигде нет... Вы остаетесь один в темноте...', false);
      }
    }}
  ]);
}

function ShowEnding(number, message, isGood) {
  print(`<br>=== КОНЦОВКА #${number} ===`);
  print(message);
  print(isGood ? "★ ХОРОШАЯ КОНЦОВКА ★" : "✖ ПЛОХАЯ КОНЦОВКА ✖");
  print("<br>Спасибо за игру!");
  showChoices([
    { text: 'Начать заново', action: () => location.reload() }
  ]);
}

// Запуск игры
askName();
