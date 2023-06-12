using AspNetCoreMvcSample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace AspNetCoreMvcSample.ViewComponents
{
    public class RoomListViewComponent : ViewComponent
    {
        public ViewViewComponentResult Invoke()
        {
            List<Room> roomList = new List<Room>()
            {
                new Room()
                {
                    Description="Lüks Balayı Suit",
                    ImageUrl="https://www.hilton.com/im/en/ISTMAHI/11105506/istmakingsuite4.jpg?impolicy=crop&cw=4500&ch=2557&gravity=NorthWest&xposition=0&yposition=221&rw=760&rh=432"
                },
                new Room()
                {
                    Description="2 Yatak Odalı Aile Odası",
                    ImageUrl="https://www.hilton.com/im/en/ISTMAHI/7190574/2maslak-double-queen-bed-deluxe-room.jpg?impolicy=crop&cw=4947&ch=2812&gravity=NorthWest&xposition=26&yposition=0&rw=760&rh=432"
                },
                new Room()
                {
                    Description="King Guest Room"  ,
                    ImageUrl="https://www.hilton.com/im/en/ISTMIHI/14778495/king-deluxexeterasl2.jpg?impolicy=crop&cw=9114&ch=5181&gravity=NorthWest&xposition=1319&yposition=0&rw=760&rh=432"
                }

            };
            return View(new RoomViewModel
            {
                Rooms = roomList
            });
        }
    }
}
