# Gaussian-Splatts-into-Unity-

Aim : turn a video streram of a drone into a world on unity with the least points , rather then point cloud and a lot of data processing 

What is Gaussian Splatt?



https://github.com/user-attachments/assets/6151d592-95f9-4596-a79b-274bd1fe4e91





<img width="603" height="232" alt="image" src="https://github.com/user-attachments/assets/9e2315d0-dc8c-4b06-a323-d2b3530a2a91" />



Steps to first extract the points of the raw video 
1. use 'ffmeg' to extract overlaping frames of the videos as images in a file 
<img width="1227" height="590" alt="image" src="https://github.com/user-attachments/assets/d2b2863a-e3e2-417b-bfc9-11ea9a790441" />

I wrote a command to trim the video to a few seconds whree the video is how=cering over the scene , and created images saved in a pre created folder 'img' 

- ffmpeg -i stonehenge.mp4 -ss 00:00:31 -to 00:06:03 -vf "fps=1,scale=iw:ih:flags=lanczos" -c:v mjpeg -q:v 2 -y ./img/frame_%05d.jpg


2. use 'RealityScan' to create poses
<img width="1918" height="1011" alt="image" src="https://github.com/user-attachments/assets/4b59e4bc-75a8-4320-acc7-1be4d6d079d4" />

 - ulter settings based on video , in this case
 - <img width="421" height="362" alt="image" src="https://github.com/user-attachments/assets/bc727191-0af6-43de-88b5-91e567f93d6b" />
 
 - try alignment and remove small (noise compartments) and repeat aligning , this improves quality
 - ulter settings again to orginal down sca;e and error reprojection 

<img width="421" height="422" alt="image" src="https://github.com/user-attachments/assets/af485a4f-8eda-43aa-bf2e-83a060be89e7" />

- export settings to colmap , as images with orginal namimg
- <img width="1919" height="1018" alt="image" src="https://github.com/user-attachments/assets/bddff2eb-14ef-4a35-9dda-840e2fd85d99" />

<img width="1146" height="922" alt="image" src="https://github.com/user-attachments/assets/29de3639-cf3b-4ecd-b5c7-6d47dec53241" />


3. start Brush to create Gaussian Splat Training
- Download from
- https://github.com/ArthurBrussee/brush/releases
  
Training Process: 




https://github.com/user-attachments/assets/ce0f6f73-c3c2-4517-9d16-d7d31d76b898


<img width="1919" height="1020" alt="image" src="https://github.com/user-attachments/assets/c3f0aa2a-b54f-4d6c-a876-7c75a91afbee" />

then export as ply , if we need to remove a bacground edit or clean we can use super splat but it is good enough to take from there and import on unity 

4. clone SPZ Unity Importer to import the .ply in unity
   
link: https://github.com/aras-p/UnityGaussianSplatting

<img width="1464" height="740" alt="image" src="https://github.com/user-attachments/assets/99a734e6-a2d7-47b4-96c3-044a3cf0e372" />
<img width="1007" height="321" alt="image" src="https://github.com/user-attachments/assets/b9e0cdf5-0678-4453-8574-3a8395d39184" />


5. pick HDRP to match the latest Unity
   
<img width="1857" height="820" alt="image" src="https://github.com/user-attachments/assets/be559b5c-fe69-4d5c-9d86-e57829e6f218" />

6. convert anything needed to match

<img width="1919" height="1027" alt="image" src="https://github.com/user-attachments/assets/62382ecc-6af9-478c-b987-551de4be42b1" />

7. Create Guassian Splatt asset

<img width="1919" height="977" alt="image" src="https://github.com/user-attachments/assets/cfd38df2-7c4c-42e5-90c6-42e0387450f0" />

8. drag and drop .ply and view it

Result: UNITY viewing .PlY:



https://github.com/user-attachments/assets/fa48bbb3-f3b5-40ad-94f3-7fcc5600c501



9. 
10. 
11. 
