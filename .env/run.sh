#! /bin/bash

TAG=$1
CONTAINER=$2

DIR=$(dirname "$0")

docker run --rm \
    --privileged \
    -h ${TAG} \
    -e DISPLAY \
    -e CONTAINER=${CONTAINER} \
    -v /tmp/.X11-unix:/tmp/.X11-unix:rw \
    -v $DIR/../:$DIR/../ \
    -v /var/run/docker.sock:/var/run/docker.sock:rw \
    -v $HOME/.ssh:$HOME/.ssh \
    -v $HOME/.gitconfig:$HOME/.gitconfig \
    -v $DIR/home/composer:/home/$(whoami)/.composer \
    -v $DIR/home/config/JetBrains:/home/$(whoami)/.config/JetBrains \
    -v $DIR/home/local/share/JetBrains:/home/$(whoami)/.local/share/JetBrains \
    -v $DIR/home/java:/home/$(whoami)/.java \
    -v $DIR/home/cache/JetBrains:/home/$(whoami)/.cache/JetBrains \
    -v $DIR/home/npm:/home/$(whoami)/.npm \
    -v $DIR/home/cache/mozilla:/home/$(whoami)/.cache/mozilla \
    -v $DIR/home/mozilla:/home/$(whoami)/.mozilla \
    -v $DIR/home/nuget:/home/$(whoami)/.nuget \
    --net=host \
    -w $DIR/../ \
    -it ${CONTAINER}

