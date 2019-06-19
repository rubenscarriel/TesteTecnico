FROM node:12.2.0-alpine

# RUN mkdir /usr/app
COPY . /usr/app

WORKDIR /usr/app

ENV PATH /usr/app/node_modules/.bin:$PATH

RUN npm install --silent
RUN npm install react-scripts@3.0.1 -g --silent

# start app
CMD ["npm", "start"]