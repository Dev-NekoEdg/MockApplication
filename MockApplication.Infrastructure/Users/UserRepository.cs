using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using MockApplication.Domain.Configs;
using MockApplication.Domain.Entities;
using System.Xml.Linq;

namespace MockApplication.Infrastructure.Users;

public class UserRepository : IUserRepository
{
    private XDocument xdocument;
    //private PathProvider pathProvider;
    private string path;
    private readonly DocumentConfig config;
    private readonly IHostingEnvironment environment;

    public UserRepository(IOptions<DocumentConfig> options,
        IHostingEnvironment environment)
    {
        this.environment = environment;

        string wwwPath = this.environment.WebRootPath;
        string contentPath = this.environment.ContentRootPath; // This Works.

        config = options.Value;

        path = Path.Combine(contentPath, config.FolderXmlData, config.Users);
        xdocument = XDocument.Load(path);
    }

    public async Task<User> CreateAsync(User dto)
    {
        XElement xElement = new XElement("User");
        xElement.SetAttributeValue("UserId", dto.UserId);
        xElement.Add(new XElement("FirstName", dto.FirstName));
        xElement.Add(new XElement("LastName", dto.LastName));
        xElement.Add(new XElement("Email", dto.Email));
        xElement.Add(new XElement("IdentificationType", dto.IdentificationType));
        xElement.Add(new XElement("IdentificationNumber", dto.IdentificationNumber));
        xElement.Add(new XElement("DateBirth", dto.DateBirth.ToShortDateString()));
        xElement.Add(new XElement("Height", dto.Height));
        xElement.Add(new XElement("Weight", dto.Weight));
        xElement.Add(new XElement("HasAnyDisabilitys", dto.HasAnyDisabilitys));

        xdocument.Element("Users").Add(xElement); //This tag must be the root tag in your XML file.
        xdocument.Save(path);
        return dto;
    }

    public async Task<bool> DeleteAsync(string id)
    {
        XElement xElement = GetXElement(id.ToString());
        xElement.Remove();
        xdocument.Save(path);
        return true;
    }

    public async Task<User> ReadAsync(string id)
    {
        var query = from data in xdocument.Descendants("User")
                    where data.Attribute("UserId").Value == id
                    select new User
                    {
                        UserId = data.Attribute("UserId").Value,
                        FirstName = data.Element("FirstName").Value,
                        LastName = data.Element("LastName").Value,
                        Email = data.Element("Email").Value,
                        IdentificationType = Convert.ToInt16(data.Element("IdentificationType").Value),
                        IdentificationNumber = data.Element("IdentificationNumber").Value,
                        DateBirth = Convert.ToDateTime(data.Element("DateBirth").Value),
                        Height = Convert.ToDouble(data.Element("Height").Value),
                        Weight = Convert.ToDouble(data.Element("Weight").Value),
                        HasAnyDisabilitys = Convert.ToBoolean(data.Element("HasAnyDisabilitys").Value)
                    };

        return query.FirstOrDefault();
    }

    public async Task<IList<User>> ReadAllAsync()
    {
        var query = from data in xdocument.Descendants("User")
                    select new User
                    {
                        UserId = data.Attribute("UserId").Value,
                        FirstName = data.Element("FirstName").Value,
                        LastName = data.Element("LastName").Value,
                        Email = data.Element("Email").Value,
                        IdentificationType = Convert.ToInt32(data.Element("IdentificationType").Value),
                        IdentificationNumber = data.Element("IdentificationNumber").Value,
                        DateBirth = Convert.ToDateTime(data.Element("DateBirth").Value),
                        Height = Convert.ToDouble(data.Element("Height").Value),
                        Weight = Convert.ToDouble(data.Element("Weight").Value),
                        HasAnyDisabilitys = Convert.ToBoolean(data.Element("HasAnyDisabilitys").Value)
                    };

        return query.ToList();
    }

    public async Task<User> UpdateAsync(User dto)
    {
        XElement xElement = GetXElement(dto.UserId);

        xElement.Element("FirstName").Value = dto.FirstName;
        xElement.Element("LastName").Value = dto.LastName;
        xElement.Element("Email").Value = dto.Email;
        xElement.Element("IdentificationType").Value = dto.IdentificationType.ToString();
        xElement.Element("IdentificationNumber").Value = dto.IdentificationNumber;
        xElement.Element("DateBirth").Value = dto.DateBirth.ToShortDateString();
        xElement.Element("Height").Value = dto.Height.ToString();
        xElement.Element("Weight").Value = dto.Weight.ToString();
        xElement.Element("HasAnyDisabilitys").Value = dto.HasAnyDisabilitys.ToString();

        xdocument.Save(path);

        return dto;
    }

    private XElement GetXElement(string id)
    {
        var query = from data in xdocument.Descendants("User")
                    where data.Attribute("UserId").Value == id
                    select data;

        return query.FirstOrDefault();
    }

}
