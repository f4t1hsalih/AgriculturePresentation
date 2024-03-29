﻿using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    //: IGenericDal<Team> yapısı generic dalın içinde bulunan tüm özelliklerin bu interface içinde kullanılacağını gösterir
    //yani generic dalda bulunan özellikler bu interface'e de aktarılır
    //Sondaki <Team> ifadeside generic dalda bulunan özeliiklerin Team entitysi için uygulanacağını gösterir
    public interface ITeamDal : IGenericDal<Team>
    {
    }
}
