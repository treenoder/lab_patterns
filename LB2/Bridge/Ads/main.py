from abc import ABC, abstractmethod


class AdPlatform(ABC):
    @abstractmethod
    def show_ad(self, content: str):
        pass


class WebAdPlatform(AdPlatform):
    def show_ad(self, content: str):
        print(f"Displaying web ad: {content}")


class MobileAdPlatform(AdPlatform):
    def show_ad(self, content: str):
        print(f"Displaying mobile ad: {content}")


class TvAdPlatform(AdPlatform):
    def show_ad(self, content: str):
        print(f"Displaying TV ad: {content}")


class AdCampaign(ABC):
    def __init__(self, platform: AdPlatform):
        self.platform = platform

    @abstractmethod
    def create_ad(self, content: str):
        pass


class OnlineAdCampaign(AdCampaign):
    def create_ad(self, content: str):
        print("Creating online ad campaign...")
        self.platform.show_ad(content)


class TvAdCampaign(AdCampaign):
    def create_ad(self, content: str):
        print("Creating TV ad campaign...")
        self.platform.show_ad(content)


# Приклад використання
if __name__ == "__main__":
    web_platform = WebAdPlatform()
    mobile_platform = MobileAdPlatform()
    tv_platform = TvAdPlatform()

    online_campaign = OnlineAdCampaign(web_platform)
    online_campaign.create_ad("Summer Sale - 50% Off!")

    mobile_campaign = OnlineAdCampaign(mobile_platform)
    mobile_campaign.create_ad("Download our new app!")

    tv_campaign = TvAdCampaign(tv_platform)
    tv_campaign.create_ad("Prime Time TV Commercial")

# Output:
# Creating online ad campaign...
# Displaying web ad: Summer Sale - 50% Off!
# Creating online ad campaign...
# Displaying mobile ad: Download our new app!
# Creating TV ad campaign...
# Displaying TV ad: Prime Time TV Commercial
