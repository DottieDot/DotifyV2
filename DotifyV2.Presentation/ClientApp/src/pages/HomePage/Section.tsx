import { Button, Divider, Typography } from '@material-ui/core'
import React, { Fragment, ReactNode, useCallback, useEffect, useState } from 'react'
import { MediaGrid } from '../../components'

interface Props<TItem> {
  batchSize?: number
  title: string
  load: (offset: number, count: number) => Promise<TItem[]>
  renderItem: (item: TItem) => ReactNode
}

export default function <TItem>({ batchSize = 10, title, renderItem, load }: Props<TItem>) {
  const [items, setItems] = useState<TItem[] | null>(null)
  const [loading, setLoading] = useState(false)
  const [loadedAll, setLoadedAll] = useState(false)

  const loadItems = useCallback(async () => {
    if (loading || loadedAll)
      return
    setLoading(true)
    const result = await load(items?.length ?? 0, batchSize)
    if (result.length) {
      setItems([
        ...(items ?? []),
        ...result,
      ])
    }
    setLoadedAll(result.length !== batchSize)
    setLoading(false)
  }, [items, setItems, setLoading, loading, loadedAll, setLoadedAll])

  useEffect(() => {
    if (items === null) {
      loadItems()
    }
  }, [loadItems, items, setItems])

  if (items === null) {
    return (
      <h1>Loading!</h1>
    )
  }

  return (
    <Fragment>
      <Typography
        variant="h5"
        component="h2"
        gutterBottom
      >
        {title}
      </Typography>
      <Divider variant="fullWidth" />
      <MediaGrid horizontal>
        {items.map(renderItem)}
        {!loadedAll && (
          <Button
            onClick={loadItems}
            disabled={loading}
          >
            Load Next
          </Button>
        )}
      </MediaGrid>
    </Fragment>
  )
}
