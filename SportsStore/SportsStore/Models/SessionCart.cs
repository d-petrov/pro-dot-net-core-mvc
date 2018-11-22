using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SportsStore.Infrastructure;

namespace SportsStore.Models
{
    public class SessionCart : Cart
    {
        [JsonIgnore]
        public ISession Session { get; set; }

        private static ISession GetSessionObjectFromService(IServiceProvider service)
        {
            return service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
        }
        
        private static SessionCart GetCartFromSession(ISession session)
        {
            SessionCart cart = session?.GetJson<SessionCart>(SessionKey) ?? new SessionCart();
            cart.Session = session;
            return cart;
        }

        private static void SetCartToSession(ISession session, SessionCart cart)
        {
            if(cart != null)
            {
                session?.SetJson(SessionKey, cart);
            }            
        }

        private static void SetCart(IServiceProvider service, SessionCart cart)
        {
            ISession session = GetSessionObjectFromService(service);
            SetCartToSession(session, cart);
        }

        public static SessionCart GetCart(IServiceProvider service)
        {
            ISession session = GetSessionObjectFromService(service);
            return GetCartFromSession(session);
        }

        public override void AddItem(Product product, int quantity)
        {
            base.AddItem(product, quantity);
            SetCartToSession(Session, this);
        }
        public override void RemoveItem(Product product)
        {
            base.RemoveItem(product);
            SetCartToSession(Session, this);
        }
        public override void RemoveItem(int productId)
        {
            base.RemoveItem(productId);
            SetCartToSession(Session, this);
        }
        public override void RemoveAllItems()
        {
            base.RemoveAllItems();
            SetCartToSession(Session, this);
        }
    }
}
