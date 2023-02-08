#!/bin/bash

VERSION=${1:-latest}
GIT=$(git rev-parse --short HEAD)
REGISTRY=registry.kubernetes.trion-training.de
IMAGE=csi-backend

TAG=${REGISTRY}/${USER}/${IMAGE}:${VERSION}

echo "Baue ${TAG}..."

#build
docker build -t ${TAG} .

#in registry bereitstellen
docker push ${TAG}

