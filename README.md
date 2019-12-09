<h1 style="text-align: center">GrandpARents</h1>

###### Authors: Shang-Yun Yeh, Ru Wang, Ningshan Li, Ying-An Chen, Jordan Gassaway, Ulrich Ziegler

## 1. Overview

Our goal is to develop an AR application that helps elderly people with visual and/or hearing impairments to cope with their daily tasks. The people who suffer from these impairments often have difficulties processing small textual information visually and communicating with other people. With our AR App ‘GrandpArents’, we can boost elderly people’s confidence in interpersonal and social settings, so that they can master their lives without being limited by their current perception abilities. 

We will focus on two main features to the users of our App. The first feature is a real-time subtitling functionality for one-on-one conversations. With this feature, our app will show a transcription of the spoken words of the communication partner and display it in the user's field of vision, comparable to subtitles when watching a movie. This helps the hearing impaired person not only to understand the spoken words, but most importantly bring them back into the conversation. The functionality is implemented with MRTK dictation system in Unity.

With our second feature we want to help visually impaired people who have difficulties reading small text passages. With digital zoom, our app allows the user to select an area of interest in a textbook or newspaper that appears too blurry to read, and has it magnified. The magnification is a static image that is large enough for the user to read the text passage, so the user can focus on the content and understand it efficiently.

## 2. Motivation 
Elderly people often experience diminished hearing and eyesight as they age. These conditions often present complications in performing daily tasks such as reading, communicating, or being aware of your environment. According to a survey by the National Institute on Deafness and Other Communication Disorders(NIDCD), approximately one in three people in the United States between the ages of 65 and 74 has hearing loss, and nearly half of those older than 75 have difficulty hearing, resulting in troubles in their daily life like following the doctor’s advice, hearing phones, etc. In terms of seeing, 37 million Americans older than 50 years suffer from vision loss, and one in four is older than 80, which is associated with increased fall risk, loss of independence, depression, and increased all-cause mortality.

Our system aims to solve problems elderly people encounter in their daily life caused by hearing impairment and eyesight loss. We also want to make the system easy to use, reducing the user’s learning curve. In this case, AR application is a good fit for solving this problem since we can make full use of the real space and hand gestures, making the application more user-friendly to elderly people. Overall, we propose an AR application described in the following sections.

## 3. Features
The proposed AR App consists of the following two functionalities:

* ### Real-time English subtitles for one-on-one conversation

    When the user talks to a person face to face, a subtitle will show in front of the user. The subtitle contains the words the other person utters in real-time, and it can be activated automatically when the other person is speaking. The font size and the box size can be adjusted according to the user’s preference. In the future, we may have the subtitle fixed to the position of the speaker, so that the system can support multi-person chatting scenario.

* ### Digital enlargement of a static image (Image Magnification)
    
    The user would have a semi-transparent quad following and face the user as the cursor for the area the user wants to magnify. By air-tapping the quad, the magnified image of area enclosed will appear in front of the user. The image will rotate so it is always facing the user. We can only have one magnified image at a time. Therefore, once the user looks at the zoomed image (put the camera cursor on the image) and air-tap again, the image will disappear and the quad cursor will appear again, so the user will be able to zoom a new area again. This feature is for reading small sized text passages as they appear in newspapers, magazines or textbooks. But we can think of further fields of application for the future, e.g. when looking for objects, zooming to people’s faces etc.

* ### User Interface
    
    Mainly, we only use air-tap to control the whole functionality and mostly our features works automatically. Hence, we believe that everyone using this application would get the hang of it pretty quick.

## 4. Technical Architecture

Our system can be broken into two main features Digital Zoom and Conversation Subtitles. Each feature will have separate UI components with a means of navigating between the two features. The digital zoom function will use the Hololens camera for taking pictures and an image processing library for doing the zoom/enhancement. The Conversation Subtitles function will need to access the microphone to record audio, and then will pass the audio to the MRTK dictation service to transcribe the audio.

## 5. Impact

The proposed application GrandpARents is expected to have a broad impact on the life of the elderly society. They will be able to join events, interact in social settings and gather textual information that they would not have due to visual impairments. In the following we will explain the expected impact on the elderly people’s life for each feature.

The real-time subtitles for one-on-one conversation is expected to facilitate the interaction with a person in close proximity and enable smooth communication with them. The user can better interact in the conversation without missing vital content of the spoken words. We furthermore expect our app to also have a significant impact on the communication partner, since one will be able to have a more fluent and deeper conversation with the hearing impaired person. This will especially help in critical situations, where it's important the message is conveyed clearly. 

The digital zoom feature is expected to improve visual perception abilities of elderly people. With the use of magnification, the user can view written information from newspapers, magazines and textbooks and consequently gather new knowledge about topics of interest. Additionally our app will help reduce errors in scenarios where a high degree of precision is needed, e.g. copying numbers off a sheet while doing taxes. Lastly, we expect our app to help overcome learning difficulties that stem from age related vision impairments.
