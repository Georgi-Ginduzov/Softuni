using InfluencerManagerApp.Core.Contracts;
using InfluencerManagerApp.Models;
using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories;
using InfluencerManagerApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Core
{
    public class Controller : IController
    {
        private  IRepository<IInfluencer> influencers;
        private  IRepository<ICampaign> campaigns;

        public Controller()
        {
            influencers = new InfluencerRepository();
            campaigns = new CampaignRepository();
        }

        public string ApplicationReport()
        {
            throw new NotImplementedException();
        }

        public string AttractInfluencer(string brand, string username)
        {
            IInfluencer influencer = influencers.FindByName(username);

            if (influencer == null)
            {
                return $"{nameof(InfluencerRepository)} has no {username} registered in the application.";
            }

            ICampaign campaign = campaigns.FindByName(brand);

            if (campaign == null)
            {
                return $"There is no campaign from {brand} in the application.";
            }

            if(campaign.Contributors.Contains(username))
            {
                return $"{username} is already engaged for the {brand} campaign.";
            }

            string campaignType = campaign.GetType().Name;
            string influencerType = influencer.GetType().Name;

            if (campaignType == "ProductCampaign" && influencerType == "BloggerInfluencer")
            {
                return $"{username} is not eligible for the {brand} campaign.";
            }
            else if (campaignType == "ServiceCampaign" && influencerType == "FashionInfluencer")
            {
                return $"{username} is not eligible for the {brand} campaign.";
            }

            if (campaign.Budget < influencer.CalculateCampaignPrice())
            {
                return $"The budget for {brand} is insufficient to engage {username}.";
            }
        }

        public string BeginCampaign(string typeName, string brand)
        {
            ICampaign campaign = campaigns.FindByName(brand);

            switch (typeName)
            {
                case "ProductCampaign":
                    if (campaign != null)
                    {
                        return $"{brand} campaign cannot be duplicated.";
                    }

                    campaigns.AddModel(new ProductCampaign(brand));

                    break;
                case "ServiceCampaign":
                    if (campaign != null)
                    {
                        return $"{brand} campaign cannot be duplicated.";
                    }

                    campaigns.AddModel(new ServiceCampaign(brand));

                    break;
                default:
                    return $"{typeName} is not a valid campaign in the application.";
            }

            return $"{brand} started a {typeName}.";
        }

        public string CloseCampaign(string brand)
        {
            throw new NotImplementedException();
        }

        public string ConcludeAppContract(string username)
        {
            throw new NotImplementedException();
        }

        public string FundCampaign(string brand, double amount)
        {
            throw new NotImplementedException();
        }

        public string RegisterInfluencer(string typeName, string username, int followers)
        {
            IInfluencer influencer = influencers.FindByName(username);
            
            switch (typeName)
            {
                case "BusinessInfluencer":
                    if (influencer != null)
                    {
                        return $"{username} is already registered in {typeName}.";
                    }
                    influencers.AddModel(new BusinessInfluencer(username, followers));

                    break;
                case "FashionInfluencer":
                    if (influencer != null)
                    {
                        return $"{username} is already registered in {typeName}.";
                    }

                    influencers.AddModel(new FashionInfluencer(username, followers));

                    break;
                case "BloggerInfluencer":
                    if (influencer != null)
                    {
                        return $"{username} is already registered in {typeName}.";
                    }

                    influencers.AddModel(new BloggerInfluencer(username, followers));

                    break;
                default:
                    return $"{typeName} has not passed validation.";
            }

            return $"{username} registered successfully to the application.";
        }
    }
}
