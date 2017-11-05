# Show your computer desktop as an Amazon Echo Smart Home Security Camera

These are source files associated with my *Your computer screen as an Alexa Smart Home Security Camera* screencast.

Assuming the desktop whose stream your want to stream is called *desktop.lan*, and the Ubuntu Server running Docker is called *your.dockerhostcomputer.com* (domain name registered in DNS with your computer's private address)

The command I run on the computer whose desktop I stream (desktop.lan):
```
vlc "screen://" --sout-keep  --sout "#transcode{vcodec=h264,acodec=none,fps=60,scale=0.5}:rtp{sdp=rtsp://:8554/1}"
```

The commands I use to generate SSL certs on the Ubuntu box:
```
docker run -it certbot/certbot -d your.dockerhostcomputer.com --rsa-key-size 4096 --manual --preferred-challenges dns certonly
```

The command I use to build the docker image (in the [Docker](Docker) subfolder), after I put the generated certs in the *certs* subfolder:
```
docker build . -t live555proxy
```

The command I use to run the docker image:
```
docker run -it -p 443:443 live555proxy /bin/bash -c "stunnel;live/proxyServer/live555ProxyServer -V rtsp://desktop.lan:8554/1"
```
