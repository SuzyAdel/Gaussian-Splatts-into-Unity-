# Gaussian-Splatts-into-Unity-

Aim : turn a video streram of a drone into a world on unity with the least points , rather then point cloud and a lot of data processing 

What is Gaussian Splatt?

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
https://github.com/user-attachments/assets/565afdfe-79ff-48e2-ae40-363f44d39bc5




4. 
5. 
6. 
7. 
