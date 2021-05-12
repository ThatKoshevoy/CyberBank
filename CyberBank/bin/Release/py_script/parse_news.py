from bs4 import BeautifulSoup
import requests

URL = f'https://meduza.io'
HEADERS = {
    'User-Agent': 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.182 Safari/537.36'
}
response = requests.get(URL, headers=HEADERS)
soup = BeautifulSoup(response.content, 'html.parser')
items = soup.findAll('div', class_='SimpleBlock-content')
comps = []
news_list = []
check = 0
equal = False
x=1
for item in items:
    comps.append({
        'title': item.find('span', class_='BlockTitle-first').get_text(strip=True)
    })
    for comp in comps:
        if len(news_list) < 5:
            while check < len(news_list):
                if news_list[check] == comp['title']:
                    equal = True
                check += 1
            if equal == False:
                news_list.append(comp['title'])
            equal = False
            check = 0
check = 0
while check < len(news_list):
    file = open(f"news{x}.txt", "w")
    file.write(news_list[check])
    file.close()
    check +=1
    x += 1
