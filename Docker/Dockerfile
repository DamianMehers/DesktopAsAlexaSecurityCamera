FROM ubuntu
# Damian Mehers https://damian.fyi

WORKDIR /app

# Generate certs using Let's Encrupt / Cerbot
ADD certs/* /etc/stunnel/
ADD stunnel.conf /etc/stunnel/stunnel.conf

RUN apt-get update && apt-get install -y \
  build-essential \
  make \
  wget \
  stunnel

# Build live555 replacing "proxyServer" with "h264" and increasing buffer size
RUN wget http://www.live555.com/liveMedia/public/live555-latest.tar.gz && \
  tar -xzf live555-latest.tar.gz && \
  sed -i 's/proxyStream/h264/g' live/proxyServer/live555ProxyServer.cpp && \
  sed -i 's/100000/500000/g' live/proxyServer/live555ProxyServer.cpp && \
  cd live && ./genMakefiles linux-64bit && make

# RTSP over https
EXPOSE 443