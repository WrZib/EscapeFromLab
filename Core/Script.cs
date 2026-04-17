using System.Collections.Generic;

namespace Core
{
    public static class Script
    {
        private static Dictionary<int, Scene> _scenes = new();

        public static Dictionary<int, Scene> Build()
        {
            _scenes = new Dictionary<int, Scene>();

            //0
            _scenes[0] = new Scene
            {
                Id = 0,
                Title = "Камера-изоляция",
                Text = "Ты приходишь в себя на холодной койке. Тусклая лампа, камера наблюдения в углу. На двери — панель «LOCK A». Воздух пахнет антисептиком.",
                Image = "scene0",
                Choices =
                {
                    new Choice { Text = "Осмотреться", NextSceneId = 1, Effects = { Ef.T(1) } },
                    new Choice { Text = "Подойти к двери", NextSceneId = 2, Effects = { Ef.T(1) } },
                    new Choice { Text = "Нажать интерком", NextSceneId = 3, Effects = { Ef.T(1) } },
                    new Choice { Text = "Проверить вентиляцию", NextSceneId = 4, Effects = { Ef.T(1) } },
                }
            };

            //1
            _scenes[1] = new Scene
            {
                Id = 1,
                Title = "Осмотр камеры",
                Text = "Под матрасом — тонкий провод. На стене — мутное зеркало с трещиной. На полу — бирка «S‑47».",
                Image = "scene1",
                Choices =
                {
                    new Choice
                    {
                        Text = "Взять провод",
                        NextSceneId = 1,
                        Requirements = { Req.Once("1_Wire") },
                        Effects = { Ef.Give(ItemID.Wire), Ef.Visit("1_Wire") }
                    },
                    new Choice
                    {
                        Text = "Отломить осколок зеркала",
                        NextSceneId = 1,
                        Requirements = { Req.Once("1_Shard") },
                        Effects = { Ef.Give(ItemID.Shard), Ef.Visit("1_Shard") }
                    },
                    new Choice { Text = "Вернуться", NextSceneId = 0 }
                }
            };

            //2
            _scenes[2] = new Scene
            {
                Id = 2,
                Title = "Дверь и панель",
                Text = "Панель мигает «LOCK A». Внизу щель: туда уходит проводка.",
                Image = "scene2",
                Choices =
                {
                    new Choice
                    {
                        Text = "Вскрыть панель проводом",
                        NextSceneId = 5,
                        Requirements = { Req.Item(ItemID.Wire) },
                        Effects = { Ef.AddAlarm(5), Ef.Flag(Flag.DoorBypass), Ef.T(1) }
                    },
                    new Choice
                    {
                        Text = "Вскрыть силой ломиком",
                        NextSceneId = 5,
                        Requirements = { Req.Item(ItemID.Crowbar) },
                        Effects = { Ef.AddAlarm(12), Ef.AddHealth(-5), Ef.T(1) }
                    },
                    new Choice { Text = "Отойти и подумать", NextSceneId = 0 }
                }
            };

            //3
            _scenes[3] = new Scene
            {
                Id = 3,
                Title = "Интерком",
                Text = "Динамик шипит: «Связь установлена. Идентифицируйтесь». Голос ровный, неэмоциональный.",
                Image = "scene3",
                Choices =
                {
                    new Choice
                    {
                        Text = "Спокойно назвать «S‑47»",
                        NextSceneId = 3,
                        Requirements = { Req.Once("3_S-47") },
                        Effects = { Ef.AddTrust(10), Ef.Visit("3_S-47"), Ef.Visit("3_Threat"), Ef.T(1) }
                    },
                    new Choice
                    {
                        //Сделать ответ на вопрос
                        Text = "Спросить, кто это",
                        NextSceneId = 3,
                        Effects = { Ef.T(1) }
                    },
                    new Choice
                    {
                        Text = "Угрожать",
                        NextSceneId = 3,
                        Requirements = { Req.Once("3_Threat") },
                        Effects = { Ef.AddAlarm(8), Ef.AddTrust(-10), Ef.Visit("3_Threat"), Ef.Visit("3_S-47"), Ef.T(1) }
                    },
                    new Choice { Text = "Отключиться", NextSceneId = 0 }
                }
            };

            //4
            _scenes[4] = new Scene
            {
                Id = 4,
                Title = "Вентрешётка",
                Text = "Решётка держится на винтах. Один винт «слизан». Внутри — темно и свежо.",
                Image = "scene4",
                Choices =
                {
                    new Choice
                    {
                        Text = "Открутить осколком",
                        NextSceneId = 13,
                        Requirements = { Req.Item(ItemID.Shard) },
                        Effects = { Ef.Flag(Flag.VentOpened), Ef.AddAlarm(2), Ef.T(1) }
                    },
                    new Choice
                    {
                        Text = "Открутить проводом",
                        NextSceneId = 13,
                        Requirements = { Req.Item(ItemID.Wire) },
                        Effects = { Ef.Flag(Flag.VentOpened), Ef.AddAlarm(2), Ef.T(1) }
                    },
                    new Choice
                    {
                        Text = "Поддеть ломиком",
                        NextSceneId = 13,
                        Requirements = { Req.Item(ItemID.Crowbar) },
                        Effects = { Ef.Flag(Flag.VentOpened), Ef.AddAlarm(6), Ef.T(1) }
                    },
                    new Choice { Text = "Вернуться", NextSceneId = 0 }
                }
            };

            //5
            _scenes[5] = new Scene
            {
                Id = 5,
                Title = "Коридор блока",
                Text = "Белый коридор. Справа табличка «Медпункт», дальше — камеры. В конце — зона поста/выхода.",
                Image = "scene5",
                Choices =
                {
                    new Choice
                    {
                        Text = "В кладовку уборщика",
                        NextSceneId = 7,
                        Requirements = { Req.AnyItem(ItemID.Wire, ItemID.Shard) }
                    },
                    new Choice
                    {
                        Text = "В медпункт",
                        NextSceneId = 10,
                        Requirements = { Req.Any(Req.Item(ItemID.KeyA), Req.Item(ItemID.Wire)) }
                    },
                    new Choice { Text = "К камере C‑12", NextSceneId = 11 },
                    new Choice { Text = "Дальше к посту", NextSceneId = 6 }
                }
            };

            //6
            _scenes[6] = new Scene
            {
                Id = 6,
                Title = "Пост",
                Text = "Дверь «SECURITY» закрыта, сканер просит уровень A. Рядом — лестница вниз.",
                Image = "scene6",
                Choices =
                {
                    new Choice
                    {
                        Text = "Открыть ключ‑картой A",
                        NextSceneId = 12,
                        Requirements = { Req.Item(ItemID.KeyA) },
                        Effects = { Ef.T(1) }
                    },
                    new Choice
                    {
                        //Риск
                        Text = "Вскрыть проводом",
                        NextSceneId = 12,
                        Requirements = { Req.Item(ItemID.Wire), Req.AlarmBelow(70) },
                        Effects = { new Attempt(50, new List<Effect> { Ef.AddAlarm(10) }, new List<Effect> { Ef.AddAlarm(20) }), Ef.T(2) }
                    },
                    new Choice
                    {
                        Text = "Спуститься по лестнице",
                        NextSceneId = 9,
                        Effects = { Ef.AddAlarm(4), Ef.T(1) }
                    },
                    new Choice { Text = "Вернуться", NextSceneId = 5 }
                }
            };

            //7
            _scenes[7] = new Scene
            {
                Id = 7,
                Title = "Кладовка уборщика",
                Text = "На полках — фонарь, металлический ломик, растворитель. Пахнет химией.",
                Image = "scene7",
                Choices =
                {
                    new Choice
                    {
                        Text = "Взять фонарь",
                        NextSceneId = 7,
                        Requirements = { Req.Once("7_Flash") },
                        Effects = { Ef.Give(ItemID.Flashlight), Ef.Visit("7_Flash") }
                    },
                    new Choice
                    {
                        Text = "Взять ломик",
                        NextSceneId = 7,
                        Requirements = { Req.Once("7_Crowbar") },
                        Effects = { Ef.Give(ItemID.Crowbar), Ef.Visit("7_Crowbar") }
                    },
                    new Choice
                    {
                        Text = "Взять растворитель",
                        NextSceneId = 7,
                        Requirements = { Req.Once("7_Solvent") },
                        Effects = { Ef.Give(ItemID.Solvent), Ef.Visit("7_Solvent") }
                    },
                    new Choice { Text = "Назад", NextSceneId = 5 }
                }
            };

            //8
            _scenes[8] = new Scene
            {
                Id = 8,
                Title = "Охранник",
                Text = "Охранник выходит из-за угла. Он ещё не поднял тревогу, но уже смотрит на твою бирку.",  
                Image = "scene8",
                Choices =
                {
                    new Choice
                    {
                        Text = "Замереть и спрятаться",
                        NextSceneId = 5,
                        Requirements = { Req.AlarmBelow(60) },
                        Effects = { Ef.AddAlarm(5), Ef.T(1), Ef.Visit("8_Security") }
                    },
                    new Choice
                    {
                        Text = "«Я техник. Меня вызвали…»",
                        NextSceneId = 5,
                        Effects =
                        {
                            new Attempt([ItemID.LabCoat], new List<Effect> { Ef.AddAlarm(-5) , Ef.Give(ItemID.KeyA) } , new List<Effect> { Ef.AddAlarm(15), Ef.AddHealth(-10) } ),
                            Ef.Visit("8_Security"),
                            Ef.T(1)
                        }
                    },
                    new Choice
                    {
                        Text = "Использовать седатив",
                        NextSceneId = 5,
                        Requirements = { Req.Item(ItemID.Sedative) },
                        Effects = { Ef.Give(ItemID.KeyA), Ef.AddAlarm(5), Ef.T(1), Ef.Visit("8_Security") }
                    },
                    new Choice
                    {
                        Text = "Бежать",
                        NextSceneId = 5,
                        Effects = { Ef.AddHealth(-5), Ef.AddAlarm(18), Ef.T(1), Ef.Visit("8_Security") }
                    }
                }
            };

            //9
            _scenes[9] = new Scene
            {
                Id = 9,
                Title = "Лестница",
                Text = "Лестница уходит вниз к «CENTRAL». Рядом — лифт «Сервис» (карта B).",
                Image = "scene9",
                Choices =
                {
                    new Choice
                    {
                        Text = "Спуститься по лестнице",
                        NextSceneId = 19,
                        Effects = { Ef.AddAlarm(4), Ef.T(1) }
                    },
                    new Choice
                    {
                        //Риск меньше
                        Text = "Вызвать сервисный лифт",
                        NextSceneId = 19,
                        Requirements = { Req.Item(ItemID.KeyB), Req.Flag(Flag.PowerOn) },
                        Effects = { new Attempt(20, new List<Effect> { Ef.AddAlarm(5) }, new List<Effect> { Ef.AddAlarm(30) }), Ef.T(1) }
                    },
                    new Choice { Text = "Вернуться к посту", NextSceneId = 6 }
                }
            };

            //10
            _scenes[10] = new Scene
            {
                Id = 10,
                Title = "Медпункт",
                Text = "Кушетка, шкаф лекарств. На стене плакат: «Тревога 100 — захват. Чистка — по таймеру».",
                Image = "scene10",
                Choices =
                {
                    new Choice
                    {
                        Text = "Взять аптечку",
                        NextSceneId = 10,
                        Requirements = { Req.Once("10_Medkit") },
                        Effects = { Ef.Give(ItemID.Medkit), Ef.Visit("10_Medkit") }
                    },
                    new Choice
                    {
                        Text = "Взять седатив",
                        NextSceneId = 10,
                        Requirements = { Req.Once("10_Sed") },
                        Effects = { Ef.Give(ItemID.Sedative), Ef.Visit("10_Sed") }
                    },
                    new Choice
                    {
                        Text = "Взять респиратор",
                        NextSceneId = 10,
                        Requirements = { Req.Once("10_Mask") },
                        Effects = { Ef.Give(ItemID.GasMask), Ef.Visit("10_Mask") }
                    },
                    new Choice { Text = "Выйти", NextSceneId = 8 , Requirements = { Req.Once("8_Security")} },
                    new Choice { Text = "Выйти", NextSceneId = 5 , Requirements = { Req.Again("8_Security")} }
                }
            };

            //11
            _scenes[11] = new Scene
            {
                Id = 11,
                Title = "Камера C‑12",
                Text = "За стеклом девушка: «Я Лина. Они запустят Чистку. Тебе нужен выход через КПП… или тоннель».",
                Image = "scene11",
                Choices =
                {
                    new Choice
                    {
                        Text = "Освободить Лину",
                        NextSceneId = 5,
                        Requirements = { Req.Any(Req.Item(ItemID.KeyA), Req.Item(ItemID.Crowbar), Req.TrustAtLeast(60)) },
                        Effects =
                        {
                            Ef.Flag(Flag.LinaFreed),
                            Ef.Flag(Flag.LinaWithPlayer),
                            Ef.Flag(Flag.KnowPassword),
                            Ef.AddAlarm(3),
                            Ef.T(1)
                        }
                    },
                    new Choice
                    {
                        Text = "Попросить пароль",
                        NextSceneId = 5,
                        Effects = { Ef.Flag(Flag.KnowPassword), Ef.AddTrust(5), Ef.T(1) }
                    },
                    new Choice { Text = "Уйти", NextSceneId = 5 }
                }
            };

            //12
            _scenes[12] = new Scene
            {
                Id = 12,
                Title = "Техшлюз",
                Text = "Трубы, кабели, гул. Камер меньше, но датчиков больше.",
                Image = "scene12",
                Choices =
                {
                    new Choice { Text = "В генераторную", NextSceneId = 18, Effects = { Ef.T(1) } },
                    new Choice { Text = "В серверную", NextSceneId = 14, Effects = { Ef.T(1) } },
                    new Choice { Text = "В центральный коридор", NextSceneId = 19, Effects = { Ef.T(1) } },
                    new Choice
                    {
                        Text = "В вентиляцию",
                        NextSceneId = 13,
                        Requirements = { Req.Flag(Flag.VentOpened) },
                        Effects = { Ef.T(1) }
                    }
                }
            };

            //13
            _scenes[13] = new Scene
            {
                Id = 13,
                Title = "Вентузел",
                Text = "Вентканал выходит к развилке: «SERVERS» и «MAINT».",
                Image = "scene13",
                Choices =
                {
                    new Choice { Text = "В техшлюз", NextSceneId = 12 },
                    new Choice { Text = "В серверную", NextSceneId = 14 },
                    new Choice { Text = "Назад к решётке", NextSceneId = 4 }
                }
            };

            //14
            _scenes[14] = new Scene
            {
                Id = 14,
                Title = "Серверная",
                Text = "Стойки шумят. На терминале управление доступом. На полке пачки пропусков.",
                Image = "scene14",
                Choices =
                {
                    new Choice
                    {
                        Text = "Скопировать данные",
                        NextSceneId = 14,
                        Requirements = { Req.Flag(Flag.KnowPassword), Req.Once("14_Data") },
                        Effects = { Ef.Give(ItemID.DataDrive), Ef.AddAlarm(2), Ef.Visit("14_Data"), Ef.T(1) }
                    },
                    new Choice
                    {
                        Text = "Скопировать данные",
                        NextSceneId = 14,
                        Requirements = { Req.NoFlag(Flag.KnowPassword), Req.Once("14_Data") },
                        Effects = { Ef.Give(ItemID.DataDrive), Ef.AddAlarm(15), Ef.Visit("14_Data"), Ef.T(3) }
                    },
                    new Choice
                    {
                        Text = "Отключить камеры",
                        NextSceneId = 14,
                        Requirements = { Req.Once("14_CamOff") },
                        Effects = { Ef.Flag(Flag.CamerasDisabled), Ef.AddAlarm(-10), Ef.Visit("14_CamOff"), Ef.T(1) }
                    },
                    new Choice
                    {
                        Text = "Взять ключ‑карту B",
                        NextSceneId = 14,
                        Requirements = { Req.Once("14_KeyB") },
                        Effects = { Ef.Give(ItemID.KeyB), Ef.Visit("14_KeyB"), Ef.T(1) }
                    },
                    new Choice
                    {
                        Text = "В лабораторию",
                        NextSceneId = 15,
                        Requirements = { Req.Any(Req.Item(ItemID.KeyB), Req.TrustAtLeast(50)) },
                        Effects = { Ef.T(1) }
                    }
                }
            };

            //15
            _scenes[15] = new Scene
            {
                Id = 15,
                Title = "Лаборатория «Astra»",
                Text = "Столы с пробирками, экраны с графиками. Шкаф халатов и дверь «Reagents».",
                Image = "scene15",
                Choices =
                {
                    new Choice { Text = "В склад реагентов", NextSceneId = 16, Effects = { Ef.T(1) } },
                    new Choice { Text = "В раздевалку", NextSceneId = 17, Effects = { Ef.T(1) } },
                    new Choice { Text = "Назад в серверную", NextSceneId = 14, Effects = { Ef.T(1) } },
                    new Choice { Text = "В центральный коридор", NextSceneId = 19, Effects = { Ef.T(1) } }
                }
            };

            //16
            _scenes[16] = new Scene
            {
                Id = 16,
                Title = "Склад реагентов",
                Text = "На верхней полке запасной предохранитель.",
                Image = "scene16",
                Choices =
                {
                    new Choice
                    {
                        Text = "Взять предохранитель",
                        NextSceneId = 16,
                        Requirements = { Req.Once("16_Fuse") },
                        Effects = { Ef.Give(ItemID.Fuse), Ef.Visit("16_Fuse"), Ef.T(1) }
                    },
                    new Choice { Text = "Назад", NextSceneId = 15 }
                }
            };

            //17
            _scenes[17] = new Scene
            {
                Id = 17,
                Title = "Раздевалка",
                Text = "Шкафчики персонала. В одном — халат, в другом — бейдж, в третьем — карта C.",
                Image = "scene17",
                Choices =
                {
                    new Choice
                    {
                        Text = "Взять халат",
                        NextSceneId = 17,
                        Requirements = { Req.Once("17_Coat") },
                        Effects = { Ef.Give(ItemID.LabCoat), Ef.Visit("17_Coat") }
                    },
                    new Choice
                    {
                        Text = "Взять бейдж",
                        NextSceneId = 17,
                        Requirements = { Req.Once("17_Badge") },
                        Effects = { Ef.Give(ItemID.Badge), Ef.Visit("17_Badge") }
                    },
                    new Choice
                    {
                        Text = "Взять ключ‑карту C",
                        NextSceneId = 17,
                        Requirements = { Req.Once("17_KeyC"), Req.AlarmBelow(80) },
                        Effects = { Ef.Give(ItemID.KeyC), Ef.AddAlarm(4), Ef.Visit("17_KeyC"), Ef.T(1) }
                    },
                    new Choice { Text = "Выйти в центр", NextSceneId = 19, Effects = { Ef.T(1) } }
                }
            };

            //18
            _scenes[18] = new Scene
            {
                Id = 18,
                Title = "Генераторная",
                Text = "Рёв генератора. Панель питания и блок предохранителей.",
                Image = "scene18",
                Choices =
                {
                    new Choice
                    {
                        Text = "Отключить питание",
                        NextSceneId = 18,
                        Effects = { Ef.Unflag(Flag.PowerOn), Ef.Flag(Flag.CamerasDisabled), Ef.AddAlarm(-5), Ef.T(1) }
                    },
                    new Choice
                    {
                        Text = "Эконом-режим",
                        NextSceneId = 18,
                        Effects = { Ef.AddAlarm(-3), Ef.T(1) }
                    },
                    new Choice
                    {
                        Text = "Восстановить питание предохранителем",
                        NextSceneId = 18,
                        Requirements = { Req.Item(ItemID.Fuse) },
                        Effects = { Ef.Flag(Flag.PowerOn), Ef.T(1) }
                    },
                    new Choice { Text = "Уйти в центр", NextSceneId = 19, Effects = { Ef.T(1) } }
                }
            };

            //19
            _scenes[19] = new Scene
            {
                Id = 19,
                Title = "Центральный коридор",
                Text = "Ключевой узел «ADMIN / AI CORE / EXIT». Датчики умнее, ошибок прощают меньше.",
                Image = "scene19",
                Choices =
                {
                    new Choice { Text = "К руководителю проекта", NextSceneId = 20, Effects = { Ef.T(1) } },
                    new Choice { Text = "В ядро ORION", NextSceneId = 21, Effects = { Ef.T(1) } },
                    new Choice { Text = "К админ-лифту", NextSceneId = 22, Effects = { Ef.T(1) } },
                    new Choice
                    {
                        Text = "В аварийный тоннель",
                        NextSceneId = 23,
                        Effects = { Ef.T(1) }
                    }
                }
            };

            //20
            _scenes[20] = new Scene
            {
                Id = 20,
                Title = "Кабинет руководителя",
                Text = "Руководитель смотрит спокойно: «Ты хочешь свободу? Я могу дать... новую роль».",
                Image = "scene20",
                Choices =
                {
                    new Choice { Text = "Принять сделку", NextSceneId = 106 },
                    new Choice
                    {
                        Text = "Попросить доступ C «официально»",
                        NextSceneId = 20,
                        Requirements = { Req.Any(Req.Item(ItemID.LabCoat), Req.TrustAtLeast(60)), Req.Once("20_DealKey") },
                        Effects = { Ef.Give(ItemID.KeyC), Ef.Visit("20_DealKey"), Ef.T(1) }
                    },
                    new Choice
                    {
                        Text = "Угрожать",
                        NextSceneId = 20,
                        Effects = { Ef.AddAlarm(15), Ef.AddTrust(-10), Ef.T(1) }
                    },
                    new Choice { Text = "Уйти", NextSceneId = 19, Effects = { Ef.T(1) } }
                }
            };

            //21
            _scenes[21] = new Scene
            {
                Id = 21,
                Title = "Ядро ORION",
                Text = "Экран: «ORION: диалог доступен». Голос: «S‑47, твой маршрут прогнозируем».",
                Image = "scene21",
                Choices =
                {
                    new Choice
                    {
                        Text = "Попросить открыть выход",
                        NextSceneId = 21,
                        Requirements = { Req.TrustAtLeast(60) },
                        Effects = { Ef.Flag(Flag.OrionHelps), Ef.AddAlarm(-15), Ef.AddTrust(10), Ef.T(1) }
                    },
                    new Choice
                    {
                        Text = "Передать данные ORION",
                        NextSceneId = 21,
                        Requirements = { Req.Item(ItemID.DataDrive) },
                        Effects = { Ef.Flag(Flag.OrionHelps), Ef.AddTrust(20), Ef.Take(ItemID.DataDrive), Ef.T(1) }
                    },
                    new Choice
                    {
                        Text = "Попытаться отключить ORION",
                        NextSceneId = 21,
                        Requirements = { Req.AnyItem(ItemID.Wire, ItemID.KeyC) },
                        Effects = { Ef.Flag(Flag.OrionDown), Ef.Unflag(Flag.PowerOn), Ef.AddAlarm(20), Ef.AddTrust(-20), Ef.T(2) }
                    },
                    new Choice
                    {
                        Text = "Принять «экфильтрацию» ORION",
                        NextSceneId = 107,
                        Requirements = { Req.TrustAtLeast(80), Req.Flag(Flag.OrionHelps), Req.NoFlag(Flag.OrionDown) }
                    },
                    new Choice { Text = "Уйти", NextSceneId = 19, Effects = { Ef.T(1) } }
                }
            };

            //22
            _scenes[22] = new Scene
            {
                Id = 22,
                Title = "Админ-лифт",
                Text = "Панель доступа уровня C. Индикатор тревоги мигает.",
                Image = "scene22",
                Choices =
                {
                    new Choice
                    {
                        Text = "Приложить KeyC",
                        NextSceneId = 24,
                        Requirements = { Req.Item(ItemID.KeyC), Req.Flag(Flag.PowerOn), Req.AlarmBelow(90) },
                        Effects = { Ef.T(1) }
                    },
                    new Choice
                    {
                        //Риск
                        Text = "Вскрыть проводом",
                        NextSceneId = 24,
                        Requirements = { Req.Item(ItemID.Wire), Req.AlarmBelow(70) },
                        Effects = { new Attempt(50, new List<Effect> { Ef.AddAlarm(10) }, new List<Effect> { Ef.AddAlarm(20) }), Ef.T(2) }
                    },
                    new Choice { Text = "Вернуться", NextSceneId = 19 }
                }
            };

            //23
            _scenes[23] = new Scene
            {
                Id = 23,
                Title = "Аварийный тоннель",
                Text = "Узкий бетонный тоннель. Без света идти сложно.",
                Image = "scene23",
                Choices =
                {
                    new Choice
                    {
                        Text = "Идти дальше",
                        NextSceneId = 24,
                        Requirements = { Req.Item(ItemID.Flashlight) },
                        Effects = { Ef.T(2) }
                    },
                    new Choice
                    {
                        Text = "Идти в темноте",
                        NextSceneId = 24,
                        Requirements = { Req.NoItem(ItemID.Flashlight) },
                        Effects = { Ef.AddHealth(-20), Ef.AddAlarm(10), Ef.T(3) }
                    },
                    new Choice { Text = "Вернуться", NextSceneId = 19, Effects = { Ef.T(1) } }
                }
            };

            //24
            _scenes[24] = new Scene
            {
                Id = 24,
                Title = "Поверхность: сервисная зона",
                Text = "Ты выходишь в закрытый сервисный двор. До КПП — несколько метров и один терминал.",
                Image = "scene24",
                Choices =
                {
                    new Choice { Text = "Идти к КПП", NextSceneId = 25, Effects = { Ef.T(1) } },
                    new Choice
                    {
                        Text = "Спрятаться и осмотреть периметр",
                        NextSceneId = 24,
                        Requirements = { Req.Once("24_Plan") },
                        Effects = { Ef.Flag(Flag.EvacPlanFound), Ef.Visit("24_Plan"), Ef.AddAlarm(-2), Ef.T(1) }
                    },
                    new Choice { Text = "Вернуться вниз", NextSceneId = 19, Effects = { Ef.T(1) } }
                }
            };

            //25
            _scenes[25] = new Scene
            {
                Id = 25,
                Title = "КПП",
                Text = "Турникет, камера, терминал. Можно пройти «как сотрудник», можно взломать, можно просить ORION.",
                Image = "scene25",
                Choices =
                {
                    new Choice
                    {
                        //Халат или бейдж
                        Text = "Пройти по бейджу",
                        NextSceneId = 26,
                        Requirements = { Req.Item(ItemID.Badge), Req.Item(ItemID.LabCoat), Req.AlarmBelow(80) },
                        Effects = { Ef.AddAlarm(2), Ef.T(1) }
                    },
                    new Choice
                    {
                        Text = "Взломать терминал",
                        NextSceneId = 26,
                        Requirements = { Req.AnyItem(ItemID.Wire, ItemID.KeyC) },
                        Effects = { Ef.AddAlarm(15), Ef.T(1) }
                    },
                    new Choice
                    {
                        Text = "Попросить ORION открыть",
                        NextSceneId = 26,
                        Requirements = { Req.Flag(Flag.OrionHelps), Req.TrustAtLeast(60), Req.NoFlag(Flag.OrionDown) },
                        Effects = { Ef.AddAlarm(-10), Ef.T(1) }
                    },
                    new Choice
                    {
                        Text = "Ломиться силой",
                        NextSceneId = 26,
                        Effects = { Ef.AddAlarm(25), Ef.AddHealth(-5), Ef.T(1) }
                    }
                }
            };

            //26
            _scenes[26] = new Scene
            {
                Id = 26,
                Title = "Финальный рывок",
                Text = "Турникет поддаётся. Последнее решение: кого и что ты унесёшь из этого места.",
                Image = "scene26",
                Choices =
                {
                    new Choice
                    {
                        Text = "Бежать одному",
                        NextSceneId = 100,
                        Requirements = { Req.NoFlag(Flag.LinaWithPlayer), Req.NoItem(ItemID.DataDrive) }
                    },
                    new Choice
                    {
                        Text = "Бежать одному",
                        NextSceneId = 101,
                        Requirements = { Req.NoFlag(Flag.LinaWithPlayer), Req.Item(ItemID.DataDrive) }
                    },
                    new Choice
                    {
                        Text = "Уходить с Линой",
                        NextSceneId = 102,
                        Requirements = { Req.Flag(Flag.LinaWithPlayer), Req.NoItem(ItemID.DataDrive) }
                    },
                    new Choice
                    {
                        Text = "Уходить с Линой",
                        NextSceneId = 103,
                        Requirements = { Req.Flag(Flag.LinaWithPlayer), Req.Item(ItemID.DataDrive) }
                    },
                }
            };

            //Концовки
            _scenes[100] = new Scene { Id = 100, Title = "Конец: Побег в одиночку", Text = "Ты растворяешься в ночном городе. Свобода есть, но правда остаётся под землёй.", Image = "scene100" };
            _scenes[101] = new Scene { Id = 101, Title = "Конец: Побег с доказательствами", Text = "Ты уносишь данные. Теперь у тебя есть шанс разрушить проект — и враги, которые не забудут.", Image = "scene101" };
            _scenes[102] = new Scene { Id = 102, Title = "Конец: Побег вместе с Линой", Text = "Вы уходите вдвоём. У вас есть жизнь — но нет рычага, чтобы остановить систему.", Image = "scene102" };
            _scenes[103] = new Scene { Id = 103, Title = "Конец: Лина и данные", Text = "Вы уходите с Линой и доказательствами. Это самый сильный удар по тем, кто сделал вас “материалом”.", Image = "scene103" };

            _scenes[104] = new Scene { Id = 104, Title = "Конец: Захват", Text = "Сирены. Шаги. Красный свет. Тебя скручивают в коридоре — игра окончена.", Image = "scene104" };
            _scenes[105] = new Scene { Id = 105, Title = "Конец: Протокол «Чистка»", Text = "Воздух становится тяжёлым. Ты чувствуешь, как сознание уходит. Комплекс стирает следы.", Image = "scene105" };

            _scenes[106] = new Scene { Id = 106, Title = "Конец: Сделка", Text = "Ты принимаешь сделку. Тебя не убивают — тебя переопределяют. Свобода меняется на роль.", Image = "scene106" };
            _scenes[107] = new Scene { Id = 107, Title = "Конец: Экфильтрация ORION", Text = "ORION выводит тебя наружу, стирая и переписывая документы. Ты жив — но теперь у тебя есть невидимый хозяин.", Image = "scene107" };

            return _scenes;
        }
    }
}
