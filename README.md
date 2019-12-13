# GrandpARents

###### Authors: Shang-Yun Yeh, Ru Wang, Ningshan Li, Ying-An Chen, Jordan Gassaway, Ulrich Ziegler

## 1. Introduction

Our goal is to develop an AR application that helps elderly people with visual and/or hearing impairments to cope with their daily tasks. There are two main features in our system. The first feature is real-time subtitle for one-on-one conversations; the second feature is Zoom, which allows the user to zoom in a selected area. In this README file, we will introduce this project. The user instruction is linked [here](https://github.com/WeibelLab-Teaching/CSE218_Fa19_ARengers/wiki/User-Instruction).

[image: anne and anna]

## 2. Motivation and Background
According to a survey by the National Institute on Deafness and Other Communication Disorders(NIDCD), approximately one in three people in the United States between the ages of 65 and 74 has hearing loss, and nearly half of those older than 75 have difficulty hearing, resulting in troubles in their daily life like following the doctor’s advice, hearing phones, etc. In terms of seeing, 37 million Americans older than 50 years suffer from vision loss, and one in four is older than 80, which is associated with increased fall risk, loss of independence, depression, and increased all-cause mortality.

Our system aims to solve the common problems elderly people encounter in their daily life caused by age-related hearing loss and vision loss. We also want to make the system easy to use, reducing the user’s learning curve, since our target users ar elderly people.

[image old people]

## 3. Ideation
Initially, we decided to develop an assistive system for elderly people, because population aging is a serious problem for many countries, and we can so something to help. Then, we discussed the common problems that elderly people might have, and mainly focused on vision loss and hearing loss, because AR technology can provide the user more with visual information. After that we voted for two features: Subtitle and Zoom.


## 4. System Development
### Architecture:

[Architecture]

This system is based on Microsoft HoloLens 1, and is developed with Unity + Mixed Reality Toolkit. Besides, we used Microsoft Azure's Cognitive Service for real-time transcription.

### Main Features:

1. **Real-time English subtitles for one-on-one conversation**
   - Subtitles automatically generated in front of the user when someone is talking
   - Font size can be adjusted according to the user’s preference
   - Uses Azure Speech SDK as our speech-to-text service
2. **Digital enlargement of a static image (Zooming in real life)**
   - A specific square area chosen by the user can be digitally magnified
   - By air-tapping on a square frame in front of the user, the magnified image of that area appears 
   - The user can modify the size and location of the magnified image
   - Uses the built-in camera of HoloLens

[UI sketch] 

[link to the video]

## 5. Evaluation and Team Processes

### Testing and Evaluation：

#### 1. User Test for basic functionality:

- Understand how user uses the app
- Find out whether features support user
- Find improvements for features

**Takeaways**

​	✅ Subtitle feature works well

​	❎ Zoom App has high latency



#### 2. User Test for instructions and UI

- See if user benefits from features
- Learn if instructions help user
- Gain insights on UI usability

**Takeaways**

​	✅ UI Easy and intuitive to use

​	✅ Instructions support first-time user

​	❎ UI still needs refinement



### Collaboration:

In each Sprint Cycle (1 week)

[sprint cycle diagram]

Responsibilities:

| Subtitle Feature          | Zoom Feature                |
| ------------------------- | --------------------------- |
| Jordan (UI for Subtitles) | Ningshan (UI)               |
| Ru (Speech Recognition)   | Ying-An (Image Capturing)   |
| Ulrich (UI for Menu)      | Shang-Yun (Image Capturing) |



## 6. Agile Process

[AP]



## 7. Conclusion and Future Work

We developed an assistive system for elderly people with age-related hearing loss and vision loss. In this system, we have two main features: Subtitle and Zoom. We achieved high accuracy and low latency for Subtitle, and implemented precise magnification of a selected area. 

In the future, we will be working on the following:

- Less latency for taking pictures
- Improved interaction with environment.
- Image with higher resolution.
- Wider voice capture area.
- Multiple Languages support.



## 8. Acknowledgement

This public repository is a course project for CSE 218 at UCSD, instructed by Prof. Nadir Weibel. If you are interested in this project and would like to use this application or further develop, **please contact the team first** (emails listed below). If you like the concept and want to share the video or code with others, **please cite properly!**

Ru Wang (ruw001@ucsd.edu)

Shang-Yun Yeh ()

Ningshan Li ()

Ying-An Chen ()

Jordan Gassaway ()

Ulrich Ziegler ()


