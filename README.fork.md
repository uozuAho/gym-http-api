# My fork of the AI gym http server/clients

I just want to get this working so I don't have to use python any more
than I have to.

## dependencies

- python 3.7 (google it)
- pipenv (`pip install pipenv`)

## getting started

- install dependencies
- run `pipenv install`

All further instructions assume you run commands from within a pipenv
shell, or prefix with `pipenv run`.

## running tests

Run `nose2`

## run the example agent

Start the server first: `python gym_http_server.py`
Then the agent:         `python example_agent.py`

## todo
- get demo c# client working
- fix tests
- fix render