using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetanitPatterns.SOLID
{
    static class InterfaceSegregation_Message
    {
        public static void Display()
        {
            Sender s = new Sender();
            s.SendMessage(new VoiceMessage());
            s.SendMessage(new SmsMessage());
        }

        class Sender
        {
            public void SendMessage(IMessage message)
            {
                message.Send();
            }
        }

        interface IMessage
        {
            void Send();
            string ToAddress { get; set; }
            string FromAddress { get; set; }
        }
        interface IVoiceMessage : IMessage
        {
            byte[] Voice { get; set; }
        }
        interface ITextMessage : IMessage
        {
            string Text { get; set; }
        }

        interface IEmailMessage : ITextMessage
        {
            string Subject { get; set; }
        }

        class VoiceMessage : IVoiceMessage
        {
            public string ToAddress { get; set; }
            public string FromAddress { get; set; }

            public byte[] Voice { get; set; }
            public void Send()
            {
                Console.WriteLine("Передача голосовой почты");
            }
        }
        class EmailMessage : IEmailMessage
        {
            public string Text { get; set; }
            public string Subject { get; set; }
            public string FromAddress { get; set; }
            public string ToAddress { get; set; }

            public void Send()
            {
                Console.WriteLine("Отправляем по Email сообщение: {0}", Text);
            }
        }

        class SmsMessage : ITextMessage
        {
            public string Text { get; set; }
            public string FromAddress { get; set; }
            public string ToAddress { get; set; }
            public void Send()
            {
                Console.WriteLine("Отправляем по Sms сообщение: {0}", Text);
            }
        }
    }

    static class InterfaceSegregationProblem_Message
    {
        interface IMessage
        {
            void Send();
            string Text { get; set; }
            string Subject { get; set; }
            string ToAddress { get; set; }
            string FromAddress { get; set; }
            byte[] Voice { get; set; }
        }

        class EmailMessage : IMessage
        {
            public string Subject { get; set; }
            public string Text { get; set; }
            public string FromAddress { get; set; }
            public string ToAddress { get; set; }

            public byte[] Voice
            {
                get
                {
                    throw new NotImplementedException();
                }

                set
                {
                    throw new NotImplementedException();
                }
            }

            public void Send()
            {
                Console.WriteLine("Отправляем по Email сообщение: {0}", Text);
            }
        }

        class SmsMessage : IMessage
        {
            public string Text { get; set; }
            public string FromAddress { get; set; }
            public string ToAddress { get; set; }

            public string Subject
            {
                get
                {
                    throw new NotImplementedException();
                }

                set
                {
                    throw new NotImplementedException();
                }
            }

            public byte[] Voice
            {
                get
                {
                    throw new NotImplementedException();
                }

                set
                {
                    throw new NotImplementedException();
                }
            }

            public void Send()
            {
                Console.WriteLine("Отправляем по Sms сообщение: {0}", Text);
            }
        }

        class VoiceMessage : IMessage
        {
            public string ToAddress { get; set; }
            public string FromAddress { get; set; }
            public byte[] Voice { get; set; }

            public string Text
            {
                get
                {
                    throw new NotImplementedException();
                }

                set
                {
                    throw new NotImplementedException();
                }
            }

            public string Subject
            {
                get
                {
                    throw new NotImplementedException();
                }

                set
                {
                    throw new NotImplementedException();
                }
            }

            public void Send()
            {
                Console.WriteLine("Передача голосовой почты");
            }
        }
    }

    static class InterfaceSegregation_Photo
    {
        public static void Display()
        {
            Photographer ph = new Photographer();
            ph.TakePhoto(new Camera());
            ph.TakePhoto(new Phone());
        }

        class Photographer
        {
            public void TakePhoto(IPhoto photoMaker)
            {
                photoMaker.TakePhoto();
            }
        }

        interface ICall
        {
            void Call();
        }
        interface IPhoto
        {
            void TakePhoto();
        }
        interface IVideo
        {
            void MakeVideo();
        }
        interface IWeb
        {
            void BrowseInternet();
        }

        class Camera : IPhoto
        {
            public void TakePhoto()
            {
                Console.WriteLine("Фотографируем с помощью фотокамеры");
            }
        }

        class Phone : ICall, IPhoto, IVideo, IWeb
        {
            public void Call()
            {
                Console.WriteLine("Звоним");
            }
            public void TakePhoto()
            {
                Console.WriteLine("Фотографируем с помощью смартфона");
            }
            public void MakeVideo()
            {
                Console.WriteLine("Снимаем видео");
            }
            public void BrowseInternet()
            {
                Console.WriteLine("Серфим в интернете");
            }
        }
    }

    static class InterfaceSegregationProblem_Photo
    {
        public static void Display()
        {
            Photographer photographer = new Photographer();
            Phone lumia950 = new Phone();
            photographer.TakePhoto(lumia950);
        }

        class Photographer
        {
            public void TakePhoto(Phone phone)
            {
                phone.TakePhoto();
            }
        }

        interface IPhone
        {
            void Call();
            void TakePhoto();
            void MakeVideo();
            void BrowseInternet();
        }
        class Phone : IPhone
        {
            public void Call()
            {
                Console.WriteLine("Звоним");
            }
            public void TakePhoto()
            {
                Console.WriteLine("Фотографируем");
            }
            public void MakeVideo()
            {
                Console.WriteLine("Снимаем видео");
            }
            public void BrowseInternet()
            {
                Console.WriteLine("Серфим в интернете");
            }
        }

        class Camera : IPhone
        {
            public void Call() { }
            public void TakePhoto()
            {
                Console.WriteLine("Фотографируем");
            }
            public void MakeVideo() { }
            public void BrowseInternet() { }
        }
    }
}
