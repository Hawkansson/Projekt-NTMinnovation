import { Component, OnInit } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import * as xml2js from "xml2js";
import { NewsRss } from './news-rss';

@Component({
  selector: 'app-root',
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.css"]
})

export class AppComponent {
  RssData: NewsRss;
  constructor(private http: HttpClient) {}

  UpdateFeeds() {
    const RSS_URL = `https://gadgets.ndtv.com/rss/feeds`;
    //gadgets.ndtv.com/rss/feeds
    //const RSS_URL = `https://www.svd.se/?service=rss`;
    //kanske skapa en lista och addera feeds dit, sen kan vi loopa "fetch"//
    fetch(RSS_URL)
      .then(response => response.text())
      .then(str => new window.DOMParser().parseFromString(str,"text/xml"))
      .then(data =>  {
        const items = data.querySelectorAll("item");
        let article = {
          title: '',
          image: '',
          text: '',
          date: '',
          category: '',
          link: '',
          source: ''
        };
        article.title = items[0].querySelector("title").innerHTML;
        article.link = items[0].querySelector("link").innerHTML;
        console.log(article.title);
        console.log(article.link);
        document.getElementById("title").innerHTML = article.title;
        document.getElementById("text").innerHTML = article.link;
        // items.forEach(el => {
        //   html += `
        //     <article>
        //       <img src="${el.querySelector("link").innerHTML}/image/large.png" alt="">
        //       <h2>
        //         <a href="${el.querySelector("link").innerHTML}" target="_blank" ref="noopener">
        //           ${el.querySelector("title").innerHTML}
        //         </a>
        //       </h2>
        //     </article>
        //   `;
        // });
        //document.body.insertAdjacentHTML('beforeend', html);
        //document.getElementById("rssFeed2").innerHTML = html;
      });
  }

  // GetRssFeedData() {
  //   const websiteUrl=`https://www.svd.se/?service=rss`;
  //   let feedUrl=``;
  //   fetch(websiteUrl).then((res) => {
  //     res.text().then((htmlTxt) => {
  //       var domParser = new DOMParser()
  //       let doc = domParser.parseFromString(htmlTxt, 'text/html')
  //       var feedUrl = doc.querySelector('link[type="application/rss+xml"]')
  //     })
  //   }).catch(() => console.error('Error in fetching the website'))
  //   fetch(feedUrl).then((res) => {
  //     res.text().then((xmlTxt) => {
  //       var domParser = new DOMParser()
  //       let doc = domParser.parseFromString(xmlTxt, 'text/xml')
  //       doc.querySelectorAll('item').forEach((item) => {
  //         let h1 = document.createElement('h1')
  //           h1.textContent = item.querySelector('title').textContent
  //             document.querySelector('output').appendChild(h1)
  //       })
  //     })
  //   })
  //   console.log(item);
  //   //document.getElementById("rssFeed2").innerHTML = h1;
  // }

  // GetRssFeedData() {
  //   var feed = {
  //     title: '',
  //
  //   };
  //
  //   let article = {
  //     title: '',
  //     image: '',
  //     text: '',
  //     date: '',
  //     category: '',
  //     link: '',
  //     source: ''
  //   };
  //   const requestOptions: Object = {
  //     observe: "body",
  //     responseType: "text",
  //     header: 'Access-Control-Allow-Origin: *'//headers: Access-Control-Allow-Origin: *
  //   };
  //   this.http
  //     .get<any>("https://gadgets.ndtv.com/rss/feeds", requestOptions)
  //     .subscribe(data => {
  //       let parseString = xml2js.parseString;
  //       parseString(data, (err, result: NewsRss) => {

  //         this.RssData = result;
  //         //console.log(result);
  //         //console.log(result.rss.channel[0].title);
  //         //var numberOfFeeds = result.rss.channel[0].item.length;
  //         article.title = result.rss.channel[0].item[0].title;
  //         article.text = result.rss.channel[0].item[0].description;
  //         article.image = result.rss.image;
  //         document.getElementById("title").innerHTML = article.title;
  //         document.getElementById("text").innerHTML = article.text;
  //         document.getElementById("image").innerHTML = article.image;
  //       });
  //     });
  // }

}

//export interface IRssData {}
